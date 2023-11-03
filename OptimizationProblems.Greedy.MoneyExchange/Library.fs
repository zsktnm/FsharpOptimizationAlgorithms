module OptimizationProblems.Greedy.MoneyExchange 

let solve nominals sum =
    let mapFolder state value = 
        ((value, state / value), state % value)

    nominals
    |> Seq.sortDescending
    |> Seq.mapFold mapFolder sum
    |> fst
    |> Seq.where (fun pair -> (snd pair) > 0)
    |> List.ofSeq

