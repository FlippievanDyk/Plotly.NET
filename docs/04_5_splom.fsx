(**
---
title: Scatterplot matrix
category: Distribution Charts
categoryindex: 5
index: 5
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
# Scatterplot matrix 

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to plot a scatterplot matrix (splom) in F#.

let's first create some data for the purpose of creating example charts:

*)


#r "nuget: FSharp.Data"
#r "nuget: Deedle"

open FSharp.Data
open Deedle
open Plotly.NET

let data = 
    Http.RequestString @"https://raw.githubusercontent.com/plotly/datasets/master/iris-data.csv"
    |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")

let sepalLengthData = data.["sepal length"] |> Series.values
let sepalWidthData = data.["sepal width"]  |> Series.values
let petalLengthData = data.["petal length"] |> Series.values
let petalWidthData = data.["petal width"]  |> Series.values

let colors = 
    data
    |> Frame.getCol "class"
    |> Series.values
    |> Seq.cast<string>
    |> Seq.map (fun x ->
        match x with
        | "Iris-setosa" -> 0.
        | "Iris-versicolor" -> 0.5
        | _ -> 1.
    )
    |> Color.fromColorScaleValues


(**
Using a scatterplot matrix of several different variables can help to determine whether there are any
relationships among the variables in the dataset.

## Splom of the iris dataset
*)

let splom1 = 
    Chart.Splom(
        [
            "sepal length" , sepalLengthData
            "sepal width"  , sepalWidthData
            "petal length" , petalLengthData
            "petal width"  , petalWidthData
        ],
        MarkerColor = colors
    )
    |> Chart.withLayout(
        Layout.init(
            HoverMode = StyleParam.HoverMode.Closest,
            DragMode = StyleParam.DragMode.Select
        )
    )
    |> Chart.withSize (1000,1000)


(*** condition: ipynb ***)
#if IPYNB
splom1
#endif // IPYNB

(***hide***)
splom1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Showing different parts of the plot matrix

Use `ShowDiagonal`, `ShowUpperHalf` or `ShowLowerHalf` to customize the cells shown in the scatter plot matrix. 

Here are some examples:
*)

let noDiagonal = 
    Chart.Splom(
        [
            "sepal length" , sepalLengthData
            "sepal width"  , sepalWidthData
            "petal length" , petalLengthData
            "petal width"  , petalWidthData
        ],
        MarkerColor = colors,
        ShowDiagonal = false
    )
    |> Chart.withLayout(
        Layout.init(
            HoverMode = StyleParam.HoverMode.Closest,
            DragMode = StyleParam.DragMode.Select
        )
    )
    |> Chart.withSize (1000,1000)

(*** condition: ipynb ***)
#if IPYNB
noDiagonal
#endif // IPYNB

(***hide***)
noDiagonal |> GenericChart.toChartHTML
(***include-it-raw***)


let noLowerHalf =
    Chart.Splom(
        [
            "sepal length" , sepalLengthData
            "sepal width"  , sepalWidthData
            "petal length" , petalLengthData
            "petal width"  , petalWidthData
        ],
        MarkerColor = colors,
        ShowLowerHalf = false
    )
    |> Chart.withLayout(
        Layout.init(
            HoverMode = StyleParam.HoverMode.Closest,
            DragMode = StyleParam.DragMode.Select
        )
    )
    |> Chart.withSize (1000,1000)

(*** condition: ipynb ***)
#if IPYNB
noLowerHalf
#endif // IPYNB

(***hide***)
noLowerHalf |> GenericChart.toChartHTML
(***include-it-raw***)
