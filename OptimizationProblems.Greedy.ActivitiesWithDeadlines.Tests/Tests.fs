module OptimizationProblems.Greedy.ActivitiesWithDeadlines.Tests

open NUnit.Framework
open OptimizationProblems.Greedy.ActivitiesWithDeadlines

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``one activity`` () =
    let activities = [ { Price = 10; Deadline = 3 } ]
    let expected = activities
    let actual = solve activities
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``one activity with zero deadline`` () =
    let activities = [ { Price = 10; Deadline = 0 } ]
    let actual = solve activities
    Assert.That(actual, Is.Empty)

[<Test>]
let ``two activities`` () =
    let activities = [ { Price = 10; Deadline = 3 }; { Price = 5; Deadline = 2 } ]
    let expected = activities |> set
    let actual = solve activities |> set

    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``three activities with same deadline`` () =
    let activities = [ 
        { Price = 10; Deadline = 1 }; 
        { Price = 20; Deadline = 1 };
        { Price = 30; Deadline = 1 };
    ]
    let expected = 30
    let actual = 
        solve activities 
        |> List.sumBy (fun act -> act.Price)

    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``three activities`` () =
    let activities = [ 
        { Price = 5; Deadline = 1 }; 
        { Price = 10; Deadline = 1 };
        { Price = 1; Deadline = 2 };
    ]
    let expected = 11
    let actual = 
        solve activities 
        |> List.sumBy (fun act -> act.Price)

    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``five activities`` () =
    let activities = [ 
        { Price = 10; Deadline = 1 }; 
        { Price = 5; Deadline = 1 };
        { Price = 4; Deadline = 2 };
        { Price = 4; Deadline = 3 };
        { Price = 15; Deadline = 3 };
    ]
    let expected = 29
    let actual = 
        solve activities 
        |> List.sumBy (fun act -> act.Price)

    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``complex test`` () =
    let activities = [ 
        { Price = 1; Deadline = 1 }; 
        { Price = 1; Deadline = 1 };
        { Price = 1; Deadline = 1 };
        { Price = 5; Deadline = 2 };
        { Price = 7; Deadline = 2 };
        { Price = 1; Deadline = 3 };
        { Price = 3; Deadline = 4 };
        { Price = 5; Deadline = 4 };
        { Price = 1; Deadline = 4 };
        { Price = 1; Deadline = 5 };
    ]
    let expected = 21
    let actual = 
        solve activities 
        |> List.sumBy (fun act -> act.Price)

    Assert.That(actual, Is.EqualTo(expected))
