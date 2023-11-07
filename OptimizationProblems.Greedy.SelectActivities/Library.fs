module OptimizationProblems.Greedy.SelectActivities

type Activity = {
    Start: int;
    End: int;
}

let solve (activities: Activity list) =
    let folder (state: Activity list) (value: Activity) = 
        match (state |> List.tryHead) with
        | None -> [value]
        | Some h -> 
            if (value.Start >= h.End) then
                value :: state
            else
                state

    activities
    |> List.sortBy (fun act -> act.End)
    |> List.fold folder []
    |> List.rev