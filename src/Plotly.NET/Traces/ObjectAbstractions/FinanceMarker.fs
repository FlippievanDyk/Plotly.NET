﻿namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

type FinanceMarker() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle
        ) =
        FinanceMarker()
        |> FinanceMarker.style (
            ?MarkerColor = MarkerColor,
            ?LineColor = LineColor,
            ?LineWidth = LineWidth,
            ?LineDash = LineDash

        )

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?MarkerColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?LineWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?LineDash: StyleParam.DrawingStyle
        ) =
        (fun (financeMarker: FinanceMarker) ->
            let marker = Marker.init (?Color = MarkerColor)

            let line =
                Line.init (?Color = LineColor, ?Width = LineWidth, ?Dash = LineDash)

            marker |> DynObj.setValue financeMarker "marker"
            line |> DynObj.setValue financeMarker "line"

            financeMarker)
