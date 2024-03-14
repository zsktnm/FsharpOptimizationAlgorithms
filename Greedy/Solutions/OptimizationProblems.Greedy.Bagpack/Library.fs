module OptimizationProblems.Greedy.Bagpack

type BagState = {
    Capacity: int;
    Items: (int * int) list;
}

let solve prices weights capacity  = 

    let folder (state: BagState) value =
        match value with
        | (price, weight) when weight <= state.Capacity -> { 
            Capacity = state.Capacity - weight;
            Items = (price, weight) :: state.Items }
        | _ -> state

    weights 
    |> Seq.zip prices
    |> Seq.sortByDescending (fun pair -> fst pair / snd pair)
    |> Seq.fold folder { Capacity = capacity; Items = [] } 
    |> fun bag -> bag.Items
    |> List.ofSeq
