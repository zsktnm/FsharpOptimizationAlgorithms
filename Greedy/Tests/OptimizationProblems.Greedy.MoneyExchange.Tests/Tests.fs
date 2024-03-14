module OptimizationProblems.Greedy.MoneyExchange.Tests

open NUnit.Framework

[<SetUp>]
let Setup () =
    ()


[<Test>]
let OneNominal100AndPrice100 () =
    let nominals = [ 100;]
    let price = 100
    let expected = [ (100, 1) ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let OneNominal100AndPrice300 () =
    let nominals = [ 100;]
    let price = 300
    let expected = [ (100, 3) ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let OneNominal100AndPrice25 () =
    let nominals = [ 100; ]
    let price = 25
    let actual = price |> solve nominals
    Assert.That(actual, Is.Empty)


[<Test>]
let TwoNominals10And50_Price80 () =
    let nominals = [ 10; 50]
    let price = 80
    let expected = [ (50, 1); (10, 3) ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let TwoNominals10And50_Price100 () =
    let nominals = [ 10; 50]
    let price = 100
    let expected = [ (50, 2); ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let TwoNominals10And50_Price40 () =
    let nominals = [ 10; 50]
    let price = 40
    let expected = [ (10, 4); ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let TwoNominals10And50_Price5 () =
    let nominals = [ 10; 50 ]
    let price = 5
    let actual = price |> solve nominals
    Assert.That(actual, Is.Empty)


[<Test>]
let TwoNominals10And50_Price240 () =
    let nominals = [ 10; 50]
    let price = 240
    let expected = [ (50, 4); (10, 4) ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ManyNominals_GetOnlyHighest () =
    let nominals = [ 1; 5; 10; 100; 200; 500; ]
    let price = 500
    let expected = [ (500, 1) ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ManyNominals_GetOnlyHighestSeveralTimes () =
    let nominals = [ 1; 5; 10; 100; 200; 500; ]
    let price = 5000
    let expected = [ (500, 10) ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ManyNominals_GetAllOneTime () =
    let nominals = [ 1; 5; 10; 100; 200; 500; ]
    let price = 816
    let expected = [ (500, 1); (200, 1); (100, 1); (10, 1); (5, 1); (1, 1); ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ManyNominals_SomeRandomValue2734 () =
    let nominals = [ 1; 5; 10; 100; 200; 500; ]
    let price = 2734
    let expected = [ (500, 5); (200, 1); (10, 3); (1, 4); ]
    let actual = price |> solve nominals
    Assert.That(actual, Is.EqualTo(expected))