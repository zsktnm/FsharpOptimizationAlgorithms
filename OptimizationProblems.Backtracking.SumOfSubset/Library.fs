module OptimizationProblems.Backtracking.SumOfSubset

let solve values result =
    failwith "not implemented yet"
    let cutFirst list = 
        match list |> List.length with
        | 0 -> []
        | _ -> list |> List.skip 1

    let rec loop choose queue results = 
        printfn "%A %A %A" choose queue results
        let sum = choose |> List.sum
        match queue with 
        | [] -> results
        | head :: tail when head + sum > result ->
            loop choose tail results
        | head :: tail when head + sum = result ->
            loop choose  tail (choose :: results)
        | head :: tail -> 
            loop (head :: choose) (tail @ queue) results


    loop [] values []