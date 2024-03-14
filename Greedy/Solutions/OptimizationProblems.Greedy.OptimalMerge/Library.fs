module OptimizationProblems.Greedy.OptimalMerge

let solve (lengths: int array) =
    let rec loop sum (lengths: int array) =
        match (lengths.Length) with
        | len when len < 2 -> 0
        | 2 -> lengths |> Array.sum |> (+) sum
        | _ -> 
            let sorted = lengths |> Seq.sort
            let currentSum = 
                sorted 
                |> Seq.take 2 
                |> Seq.sum

            let tail = sorted |> Seq.skip 2
            loop (currentSum + sum) [| yield currentSum; yield! tail |]

    loop 0 lengths
        

