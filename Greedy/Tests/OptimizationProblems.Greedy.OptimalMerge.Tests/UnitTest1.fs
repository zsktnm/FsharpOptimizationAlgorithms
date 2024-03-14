module OptimizationProblems.Greedy.OptimalMerge.Tests

open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``one element no merges`` () =
    let lengths = [| 2123124 |]
    let expected = 0
    let actual = solve lengths
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``two elements just sum`` () =
    let lengths = [| 10; 5 |]
    let expected = 15
    let actual = solve lengths
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``three elements one two three`` () =
    let lengths = [| 1; 2; 3 |]
    let expected = 9
    let actual = solve lengths
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``three elements six sevent eight`` () =
    let lengths = [| 6; 7; 8 |]
    let expected = 34
    let actual = solve lengths
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``four ones`` () =
    let lengths = [| 1; 1; 1; 1 |]
    let expected = 8
    let actual = solve lengths
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``four elements`` () =
    let lengths = [| 4; 5; 6; 7 |] 
    let expected = 44
    let actual = solve lengths
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``five ones`` () =
    let lengths = [| 1; 1; 1; 1; 1 |] 
    let expected = 12
    let actual = solve lengths
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``five elements`` () =
    let lengths = [| 5; 4; 7; 9; 7 |] 
    let expected = 73
    let actual = solve lengths
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``six elements`` () =
    let lengths = [| 3; 4; 5; 6; 7; 8 |] 
    let expected = 84
    let actual = solve lengths
    Assert.That(actual, Is.EqualTo(expected))