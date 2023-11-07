module OptimizationProblems.Greedy.ActivitiesWithDeadlines

type Activity = {
    Price: int;
    Deadline: int;
}

let solve (activities: Activity list) =
    let rec loop time (list: Activity list) =
        match time with
        | 0 -> []
        | _ -> 
            let selected = 
                list
                |> List.find (fun act -> act.Deadline > time) 
        
            let filtered = 
                list
                |> List.where (fun act -> act <> selected)

            selected :: loop (time - 1) filtered
        

    let time = 
        activities 
        |> List.maxBy (fun act -> act.Deadline)
        |> fun act -> act.Deadline

    activities
    |> List.sortByDescending (fun act -> act.Price)
    |> loop time