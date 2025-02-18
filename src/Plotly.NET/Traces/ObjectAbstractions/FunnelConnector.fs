﻿namespace Plotly.NET.TraceObjects

open Plotly.NET
open Plotly.NET.LayoutObjects
open DynamicObj
open System
open System.Runtime.InteropServices

/// Styles for connector lines in Funnel Charts.
///
/// Parameters:
///
/// Line          : Sets the Line style for this WaterfallConnector
///
/// Visible       : Wether or not connectors are visible
///
/// ConnectorMode : Sets the shape of connector lines.
type FunnelConnector() =
    inherit DynamicObj()

    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Fillcolor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =

        FunnelConnector() |> FunnelConnector.style (?Fillcolor = Fillcolor, ?Line = Line, ?Visible = Visible)

    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Fillcolor: Color,
            [<Optional; DefaultParameterValue(null)>] ?Line: Line,
            [<Optional; DefaultParameterValue(null)>] ?Visible: bool
        ) =
        (fun (connector: FunnelConnector) ->

            Fillcolor |> DynObj.setValueOpt connector "fillcolor"
            Line |> DynObj.setValueOpt connector "line"
            Visible |> DynObj.setValueOpt connector "visible"

            connector)
