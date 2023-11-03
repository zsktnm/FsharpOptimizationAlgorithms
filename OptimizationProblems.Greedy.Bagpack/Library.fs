module OptimizationProblems.Greedy.Bagpack

let solve prices weights capacity  = 
    let folder state value =
        let cap = fst state
        let items = snd state
        match value with
        | (price, weight) when weight <= cap -> (cap - weight, (price, weight) :: items)
        | _ -> state

    weights 
    |> Seq.zip prices
    |> Seq.sortByDescending (fun pair -> fst pair / snd pair)
    |> Seq.fold folder (capacity, [])
    |> snd
    |> List.ofSeq
