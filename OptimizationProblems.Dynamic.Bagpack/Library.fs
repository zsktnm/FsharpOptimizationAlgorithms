module OptimizationProblems.Dynamic.Bagpack


let buildTable (prices: int array) (weights: int array) (capacity: int) =
    let values = 
        Array.zeroCreate<int> (capacity + 1)
        |> List.replicate (1 + Array.length prices)
    let prices' = [| 0; yield! prices |]
    let weights' = [| 0; yield! weights |]

    let folder (state: int * int array) (current: int array) = 
        let rowIndex = fst state
        let prev = snd state 
        let result = 
            current 
            |> Array.mapi (fun index _ -> 
                match index with 
                | index when index < weights'.[rowIndex] ->
                    prev.[index]
                | index -> 
                    (prev.[index], prices'[rowIndex] + prev.[index - weights'.[rowIndex]])
                    ||> max
            )
        (result, (rowIndex + 1, result))

    values 
    |> List.skip 1
    |> List.mapFold folder (1, values |> List.head)
    |> fst



let getPrice (table: int array list) = 
    table
    |> List.last
    |> Array.last
    
    

let solve (prices: int array) (weights: int array) (capacity: int) =
    if (prices.Length <> weights.Length) then
        Error "Invalid length"
    elif (prices.Length = 0) then
        Error "Arrays is empty"
    else
        buildTable prices weights capacity
        |> getPrice
        |> Ok