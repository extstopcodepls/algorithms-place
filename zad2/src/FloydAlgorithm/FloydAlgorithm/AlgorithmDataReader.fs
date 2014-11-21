namespace FloydAlgorithm

module AlgorithmDataReader =
    
    open System

    type Node =
        {
            Label:string;
            Number:int;
            Wage:int;
        }

    type AlgorithmTextData =
        {
            StartPoint:Node;
            NodeCount:int;
            IsDirectional:bool;
            Nodes:Node list;
        }


    let get2DArrayFromFileData data =

        let node =
            let firstElement:string = List.head data
            match firstElement with
                | element ->
                    let trimmedElement = element.Trim()
                    if trimmedElement.Contains("x") then
                        { Label = trimmedElement; Number = Int32.Parse((trimmedElement.Chars 1).ToString()); Wage = 0; }
                    else
                        { Label = trimmedElement; Number = Int32.Parse(trimmedElement); Wage = 0; }
        
        
        let numberOfNodes = Int32.Parse(List.tail data |> List.head)

        let isDirectional = 
            let isDirec = Int32.Parse(List.nth data 2)
            match isDirec with
                | 0 -> false
                | 1 -> true
                | _ -> false

//        let rec getNodes list = 
//            match list with
//                | [] -> []
//                | head::tail ->
//                    let nodes 
                    
                    

            

