module OptimizationProblems.Greedy.ActivitiesWithDeadlines

type Activity = {
    Price: int;
    Deadline: int;
}


let solve (activities: Activity list) =
    let rec loop time (list: Activity list) =
        match (time, list.Length) with
        | (-1, _) | (_, 0) -> []
        | _ -> 
            let selected = 
                list
                |> List.tryFind (fun act -> act.Deadline > time) 

            match selected with
            | None -> loop (time - 1) list
            | Some activity ->
                let filtered = 
                    list
                    |> List.where (fun act -> act <> activity)
                activity :: loop (time - 1) filtered
        

    let time = 
        activities 
        |> List.maxBy (fun act -> act.Deadline)
        |> fun act -> act.Deadline

    activities
    |> List.sortByDescending (fun act -> act.Price)
    |> loop time