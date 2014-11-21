// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

namespace FloydAlgorithm

open FloydAlgorithm.AlgorithmDataReader

module Console =
    [<EntryPoint>]
    let main argv = 
        printfn "%A" argv

        let result = get2DArrayFromFileData argv

        0 // return an integer exit code
