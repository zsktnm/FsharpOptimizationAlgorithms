module OptimizationProblems.Dynamic.Bagpack.Tests

open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``one item`` () =
    let weights = [| 2; |]
    let prices = [| 100; |]
    let capacity = 4
    let expected = 100
    let actual = solve prices weights capacity

    match actual with
    | Error _ -> Assert.Fail "Result returns error"
    | Ok value -> Assert.That(value, Is.EqualTo(expected))

[<Test>]
let ``one item but small backpack`` () =
    let weights = [| 4; |]
    let prices = [| 100; |]
    let capacity = 2
    let expected = 0
    let actual = solve prices weights capacity

    match actual with
    | Error _ -> Assert.Fail "Result returns error"
    | Ok value -> Assert.That(value, Is.EqualTo(expected))


[<Test>]
let ``two items but can take only one`` () =
    let weights = [| 4; 3; |]
    let prices = [| 100; 99 |]
    let capacity = 5
    let expected = 100
    let actual = solve prices weights capacity

    match actual with
    | Error _ -> Assert.Fail "Result returns error"
    | Ok value -> Assert.That(value, Is.EqualTo(expected))



[<Test>]
let ``four items`` () =
    let weights = [| 2; 3; 4; 5 |]
    let prices = [| 1; 2; 5; 6 |]
    let capacity = 8
    let expected = 8
    let actual = solve prices weights capacity

    match actual with
    | Error _ -> Assert.Fail "Result returns error"
    | Ok value -> Assert.That(value, Is.EqualTo(expected))


[<Test>]
let ``seven items`` () =
    let weights = [| 2; 3; 5; 7; 1; 4; 1 |]
    let prices = [| 1000; 500; 1500; 700; 600; 1800; 300 |]
    let capacity = 15
    let expected = 5400
    let actual = solve prices weights capacity

    match actual with
    | Error _ -> Assert.Fail "Result returns error"
    | Ok value -> Assert.That(value, Is.EqualTo(expected))


[<Test>]
let ``invalid lengths`` () =
    let weights = [| 2; 3; 4; 5 |]
    let prices = [| 1; 2; 5; 6; 8 |]
    let capacity = 8
    let actual = solve prices weights capacity

    match actual with
    | Error _ -> Assert.Pass ()
    | Ok value -> Assert.Fail ()


[<Test>]
let ``empty arrays`` () =
    let weights = [| |]
    let prices = [| |]
    let capacity = 8
    let actual = solve prices weights capacity

    match actual with
    | Error _ -> Assert.Pass ()
    | Ok value -> Assert.Fail ()



