module OptimizationProblems.Greedy.Bagpack.Tests

open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``get one item if it is possible`` () =
    let size = 10
    let prices = [100]
    let weights = [10]
    let expected = [(100, 10)]
    let actual = solve prices weights size
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``drop one item if it's huge`` () = 
    let size = 10
    let prices = [100]
    let weights = [10000]
    let expected = []
    let actual = solve prices weights size
    Assert.That(actual, Is.Empty)

[<Test>]
let ``get two items of two`` () = 
    let size = 100
    let prices = [100; 200]
    let weights = [10; 10]
    let expected = [(100, 10); (200, 10)]
    let actual = 
        solve prices weights size 
        |> List.sortBy (fun pair -> fst pair)

    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``get better item of two with same weight`` () = 
    let size = 10
    let prices = [100; 200]
    let weights = [10; 10]
    let expected = [(200, 10)]
    let actual = 
        solve prices weights size 
        |> List.sortBy (fun pair -> fst pair)

    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``get second item but first has better price`` () = 
    let size = 10
    let prices = [1_000_000; 200]
    let weights = [15; 10]
    let expected = [(200, 10)]
    let actual = 
        solve prices weights size 
        |> List.sortBy (fun pair -> fst pair)

    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``get all items`` () = 
    let size = 21
    let prices = [1; 2; 3; 4; 5; 6]
    let weights = [1; 2; 3; 4; 5; 6]
    let expected = [(1, 1); (2, 2); (3, 3); (4, 4); (5, 5); (6, 6);]
    let actual = 
        solve prices weights size 
        |> List.sortBy (fun pair -> fst pair)

    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``all price by weight is 1`` () = 
    let size = 15
    let prices = [1; 2; 3; 4; 5; 6]
    let weights = [1; 2; 3; 4; 5; 6]
    let expected = [(1, 1); (2, 2); (3, 3); (4, 4); (5, 5);]
    let actual = 
        solve prices weights size 
        |> List.sortBy (fun pair -> fst pair)

    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``sometimes greedy algoritm can get accurate solution`` () = 
    let size = 15
    let prices = [100; 240; 300; 400; 420;]
    let weights = [5; 3; 2; 4; 6;]
    let expected = [(240, 3); (300, 2); (400, 4);  (420, 6)]
    let actual = 
        solve prices weights size 
        |> List.sortBy (fun pair -> fst pair)

    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``greedy algoritm is not accurate`` () = 
    let size = 15
    let prices = [1000; 500; 1500; 700; 600; 1800; 300]
    let weights = [2; 3; 5; 7; 1; 4; 1]
    let actual = 
        solve prices weights size 
        |> List.sortBy (fun pair -> fst pair)
        |> List.sumBy (fun pair -> fst pair)

    Assert.That(actual, Is.GreaterThanOrEqualTo(5200)) // optimal is 5400