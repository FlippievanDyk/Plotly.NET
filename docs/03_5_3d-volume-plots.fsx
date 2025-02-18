(**
---
title: 3D Volume plots
category: 3D Charts
categoryindex: 4
index: 6
---
*)

(*** hide ***)

(*** condition: prepare ***)
#r "nuget: Newtonsoft.JSON, 12.0.3"
#r "nuget: DynamicObj"
#r "../bin/Plotly.NET/netstandard2.0/Plotly.NET.dll"

(*** condition: ipynb ***)
#if IPYNB
#r "nuget: Plotly.NET, {{fsdocs-package-version}}"
#r "nuget: Plotly.NET.Interactive, {{fsdocs-package-version}}"
#endif // IPYNB

(** 
# 3D Volume plots

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create 3D-Volume charts in F#.

let's first create some data for the purpose of creating example charts:
*)

open System
open Plotly.NET 

let linspace (min,max,n) = 
    if n <= 2 then failwithf "n needs to be larger then 2"
    let bw = float (max - min) / (float n - 1.)
    Array.init n (fun i -> min + (bw * float i))

let mgrid (min,max,n) = 

    let data = linspace(min,max,n)

    let z = [|for i in 1 .. n do [|for i in 1 .. n do yield data|]|]
    let x = [|for i in 1 .. n do [|for j in 1 .. n do yield [|for k in 1 .. n do yield data.[i-1]|]|]|]
    let y = [|for i in 1 .. n do [|for j in 1 .. n do yield [|for k in 1 .. n do yield data.[j-1]|]|]|]

    x,y,z

let x,y,z = 
    mgrid(-8.,8.,40)
    |> fun (x,y,z) ->
        (x |> Array.concat |> Array.concat),
        (y |> Array.concat |> Array.concat),
        (z |> Array.concat |> Array.concat)

let values = 
    Array.map3 (fun x y z ->
        sin(x*y*z) / (x*y*z)
    ) x y z

open Plotly.NET.TraceObjects

let volume =
    Chart.Volume(
       x, y, z, values,
       Opacity=0.1,
       Surface=(Surface.init(Count=17)),
       IsoMin=0.1,
       IsoMax=0.8
    )
    
(*** condition: ipynb ***)
#if IPYNB
volume
#endif // IPYNB

(***hide***)
volume |> GenericChart.toChartHTML
(*** include-it-raw ***)
