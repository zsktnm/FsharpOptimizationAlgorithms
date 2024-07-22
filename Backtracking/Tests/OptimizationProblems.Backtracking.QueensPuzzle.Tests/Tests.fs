module OptimizationProblems.Backtracking.QueensPuzzle.Tests

open NUnit.Framework
open OptimizationProblems.Backtracking.QueensPuzzle

[<SetUp>]
let Setup () =
    ()


[<Test>]
let ``Field with size 1 has trivial solution`` () = 
    let result = solve 1
    Assert.That(result.Head[0, 0], Is.EqualTo('*'))


[<TestCase(2, TestName = "Size is two")>]
[<TestCase(3, TestName = "Size is three")>]
let ``Fields with size 2 and 3 has no solutions`` size =
    let result = solve size
    Assert.That(result.Length, Is.EqualTo(0))


[<Test>]
let ``Test field 4x4`` () = 
    let isArraysSameLengths first second =
        Array2D.length1 first = Array2D.length1 second &&
        Array2D.length2 first = Array2D.length2 second

    let arraysEquals first second =
        if isArraysSameLengths first second then
            let maxRow = Array2D.length1 first - 1
            let maxCol = Array2D.length2 first - 1
            seq {
                for i = 0 to maxRow do
                    for j = 0 to maxCol do
                        yield first[i, j] = second[i, j]
            }
            |> Seq.forall ((=) true)
        else
            false
        
    let actual = solve 4
    let expected = [
        array2D [
            [ '0'; '*'; '0'; '0' ]
            [ '0'; '0'; '0'; '*' ]
            [ '*'; '0'; '0'; '0' ]
            [ '0'; '0'; '*'; '0' ]
        ];
        array2D [
            [ '0'; '0'; '*'; '0' ]
            [ '*'; '0'; '0'; '0' ]
            [ '0'; '0'; '0'; '*' ]
            [ '0'; '*'; '0'; '0' ]
        ]
    ]

    (actual, expected)
    ||> List.forall2 (fun act exp -> arraysEquals act exp)
    |> fun areEquals -> Assert.That(areEquals, Is.True)
    

[<TestCase(5, 10)>]
[<TestCase(8, 92)>]
let ``Check fields by lengths of result`` size expectedLen = 
    let result = solve size
    Assert.That(result.Length, Is.EqualTo(expectedLen))