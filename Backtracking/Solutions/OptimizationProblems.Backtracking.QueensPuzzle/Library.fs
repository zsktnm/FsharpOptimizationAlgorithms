module OptimizationProblems.Backtracking.QueensPuzzle
let solve (size: int) = 
    let filter choices value =
        let validRow value choice = 
            (fst choice) <> (fst value)
        
        let validCol value choice = 
            (snd choice) <> (snd value)

        let validDiag (i, j) (i0, j0) = 
            i0 - j0 <> i - j

        let validRevDiag (i, j) (i0, j0) = 
            (i0 - i) <> (j - j0)

        let validCell value choice = 
            validRow value choice &&
            validCol value choice &&
            validDiag value choice &&
            validRevDiag value choice

        choices
        |> List.forall (validCell value)
        
    let toPicture values = 
        let size = values |> List.length
        let res = Array2D.create size size '0'
        values
        |> List.iter (fun (i, j) -> res[i, j] <- '*')
        res

    let rec loop (choices: (int * int) list) row = 
        match choices with
        | _ when (choices.Length = size) -> choices
        | _ ->
            [for i = 0 to size - 1 do (row, i)]
            |> List.filter (filter choices)
            |> function
                | [] -> []
                | values -> values |> List.collect (fun v -> loop (v :: choices) (row + 1))

    loop [] 0 
    |> List.chunkBySize size
    |> List.map toPicture