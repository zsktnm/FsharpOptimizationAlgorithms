module OptimizationProblems.Greedy.SelectActivities.Tests

open NUnit.Framework
open OptimizationProblems.Greedy.SelectActivities

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``select one activity`` () =
    let activites = [{ Start = 0; End = 2 }]
    let expected = [{ Start = 0; End = 2 }]
    let actual = solve activites
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``select two activities`` () =
    let activites = [{ Start = 0; End = 2 }; {Start = 2; End = 3}]
    let expected = [{ Start = 0; End = 2 }; {Start = 2; End = 3}]
    let actual = solve activites
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``select one activity from two intersected`` () =
    let activites = [{ Start = 0; End = 3 }; {Start = 2; End = 3}]
    let expected = 1
    let actual = solve activites |> List.length
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``select two activities from four two intersected pairs`` () =
    let activites = [
        { Start = 0; End = 3 }; 
        {Start = 2; End = 3}; 
        {Start = 4; End = 6}; 
        {Start = 5; End = 7}; 
    ]
    let expected = 2
    let actual = solve activites |> List.length
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``three itersected`` () =
    let activites = [
        { Start = 0; End = 10 }; 
        {Start = 9; End = 11}; 
        {Start = 10; End = 20}; 
    ]
    let expected = 2
    let actual = solve activites |> List.length
    Assert.That(expected, Is.EqualTo(actual))

[<Test>]
let ``some complex test`` () =
    let activites = [
        {Start = 1; End = 3}; 
        {Start = 1; End = 10}; 
        {Start = 2; End = 5}; 
        {Start = 3; End = 10}; 
        {Start = 3; End = 5}; 
        {Start = 4; End = 15}; 
        {Start = 5; End = 15}; 
        {Start = 7; End = 8}; 
        {Start = 8; End = 9}; 
        {Start = 10; End = 15}; 
        {Start = 10; End = 12}; 
    ]
    let expected = 5
    let actual = solve activites |> List.length
    Assert.That(expected, Is.EqualTo(actual))
