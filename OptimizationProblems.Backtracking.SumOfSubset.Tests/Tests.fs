module OptimizationProblems.Backtracking.SumOfSubset.Tests


open NUnit.Framework
open OptimizationProblems.Backtracking.SumOfSubset

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``empty collection`` () =
    let values = []
    let expected = []
    let actual = solve values 10
    CollectionAssert.AreEquivalent(expected, actual)


[<Test>]
let ``several values`` () =
    let values = [1; 2; 3; 4; 5]
    let expected = [[1; 2; 3]; [2; 4]; [1; 5];]
    let actual = solve values 6
    CollectionAssert.AreEquivalent(expected, actual)

[<Test>]
let ``several values but no sum`` () =
    let values = [1; 2; 3; 4; 5]
    let expected = []
    let actual = solve values 9999
    CollectionAssert.AreEquivalent(expected, actual)


[<Test>]
let ``same value`` () =
    let values = [2; 2; 2; 2; 2]
    let expected = [[2; 2; 2; 2]]
    let actual = solve values 8
    CollectionAssert.AreEquivalent(expected, actual)

[<Test>]
let ``test with dublicates`` () =
    let values = [1; 2; 3; 2; 1]
    let expected = [[1; 1; 2]; [1; 3]; [2; 2];]
    let actual = solve values 4
    CollectionAssert.AreEquivalent(expected, actual)

[<Test>]
let ``some hard test`` () =
    let values = [13; 12; 6; 5; 2; 4; 1; 7; 6 ]
    let expected = [[12]; [6; 6]; [5; 7]; [1; 4; 7]; [1; 5; 6]; [2; 4; 6]; [1; 2; 4; 5]]
    let actual = solve values 12
    CollectionAssert.AreEquivalent(expected, actual)