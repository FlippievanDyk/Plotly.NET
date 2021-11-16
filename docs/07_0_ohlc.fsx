(**
---
title: Candlestick Charts
category: Finance Charts
categoryindex: 8
index: 1
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
# Candlestick Charts

[![Binder]({{root}}img/badge-binder.svg)](https://mybinder.org/v2/gh/plotly/Plotly.NET/gh-pages?filepath={{fsdocs-source-basename}}.ipynb)&emsp;
[![Script]({{root}}img/badge-script.svg)]({{root}}{{fsdocs-source-basename}}.fsx)&emsp;
[![Notebook]({{root}}img/badge-notebook.svg)]({{root}}{{fsdocs-source-basename}}.ipynb)

*Summary:* This example shows how to create candlestick charts in F#.

let's first create some data for the purpose of creating example charts:
*)
#r "nuget: FSharp.Data"
#r "nuget: Deedle"

open FSharp.Data
open Deedle

let data = 
    Http.RequestString @"https://raw.githubusercontent.com/plotly/datasets/master/finance-charts-apple.csv"
    |> fun csv -> Frame.ReadCsvString(csv,true,separators=",")

let openData : seq<float> = data.["AAPL.Open"] |> Series.values
let highData : seq<float> = data.["AAPL.High"] |> Series.values
let lowData : seq<float> = data.["AAPL.Low"] |> Series.values
let closeData : seq<float> = data.["AAPL.Close"] |> Series.values
let dateData = data |> Frame.getCol "Date" |> Series.values |> Seq.map System.DateTime.Parse

(**
An open-high-low-close chart (also OHLC) is a type of chart typically used to illustrate movements in the price of a financial instrument over time. 
Each vertical line on the chart shows the price range (the highest and lowest prices) over one unit of time. 
Tick marks project from each side of the line indicating the opening price (e.g., for a daily bar chart this would be the starting price for that day) on the left, and the closing price for that time period on the right. 
The bars may be shown in different hues depending on whether prices rose or fell in that period.

You can create an OHLC chart using `Chart.OHLC`:
*)

open Plotly.NET
open Plotly.NET.TraceObjects

let ohlc1 = 
    Chart.OHLC(
        openData |> Seq.take 30,
        highData |> Seq.take 30,
        lowData |> Seq.take 30,
        closeData |> Seq.take 30,
        dateData |> Seq.take 30
    )

(*** condition: ipynb ***)
#if IPYNB
ohlc1
#endif // IPYNB

(***hide***)
ohlc1 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Changing the increasing/decresing colors
*)

let ohlc2= 
    Chart.OHLC(
        openData,
        highData,
        lowData,
        closeData,
        dateData,
        IncreasingColor = Color.fromKeyword Cyan,
        DecreasingColor = Color.fromKeyword Gray
    )

(*** condition: ipynb ***)
#if IPYNB
ohlc2
#endif // IPYNB

(***hide***)
ohlc2 |> GenericChart.toChartHTML
(***include-it-raw***)

(**
## Removing the rangeslider

If you want to hide the rangeslider, use `withXAxisRangeSlider` and hide it:
*)
open Plotly.NET.LayoutObjects

let rangeslider = RangeSlider.init(Visible=false)

let ohlc3 = 
    ohlc2
    |> Chart.withXAxisRangeSlider rangeslider

(*** condition: ipynb ***)
#if IPYNB
ohlc3
#endif // IPYNB

(***hide***)
ohlc3 |> GenericChart.toChartHTML
(***include-it-raw***)

