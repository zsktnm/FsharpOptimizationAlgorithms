module OptimizationProblems.Backtracking.SumOfSubset

let solve values result =
    let stepped list = 
        list 
        |> List.mapi (fun index _ -> list |> List.skip index)

    let rec loop choose queue results = 
        let sum = choose |> List.sum
        match queue with 
        | [] -> results
        | head :: tail when head + sum < result -> 
            tail 
            |> stepped
            |> List.collect (fun part -> loop (head :: choose) part results)
        | head :: _ when head + sum = result ->
            (head :: choose) :: results
        | _ -> results

    values
    |> stepped
    |> List.collect (fun part -> loop [] part [])
    |> List.map (fun solution -> solution |> List.sort)
    |> List.distinct
    