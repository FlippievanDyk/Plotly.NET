namespace Plotly.NET

open System.Runtime.InteropServices
open DynamicObj
open System

/// Line type inherits from dynamic object
type Line() =
    inherit DynamicObj()

    /// Initialized Line object
    static member init
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Shape: StyleParam.Shape,
            [<Optional; DefaultParameterValue(null)>] ?Dash: StyleParam.DrawingStyle,
            [<Optional; DefaultParameterValue(null)>] ?Smoothing: float,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?CAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?CMax: float,
            [<Optional; DefaultParameterValue(null)>] ?CMid: float,
            [<Optional; DefaultParameterValue(null)>] ?CMin: float,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Colorscale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: #DynamicObj
        ) =
        Line()
        |> Line.style (
            ?Color = Color,
            ?Width = Width,
            ?MultiWidth = MultiWidth,
            ?Shape = Shape,
            ?Dash = Dash,
            ?Smoothing = Smoothing,
            ?OutlierColor = OutlierColor,
            ?OutlierWidth = OutlierWidth,
            ?AutoColorScale = AutoColorScale,
            ?CAuto = CAuto,
            ?CMax = CMax,
            ?CMid = CMid,
            ?CMin = CMin,
            ?ColorAxis = ColorAxis,
            ?Colorscale = Colorscale,
            ?ReverseScale = ReverseScale,
            ?ShowScale = ShowScale,
            ?ColorBar = ColorBar

        )


    // Applies the styles to Line()
    static member style
        (
            [<Optional; DefaultParameterValue(null)>] ?Color: Color,
            [<Optional; DefaultParameterValue(null)>] ?Width: float,
            [<Optional; DefaultParameterValue(null)>] ?MultiWidth: seq<float>,
            [<Optional; DefaultParameterValue(null)>] ?Shape: StyleParam.Shape,
            [<Optional; DefaultParameterValue(null)>] ?Dash: StyleParam.DrawingStyle,
            [<Optional; DefaultParameterValue(null)>] ?Smoothing: float,
            [<Optional; DefaultParameterValue(null)>] ?OutlierColor: Color,
            [<Optional; DefaultParameterValue(null)>] ?OutlierWidth: float,
            [<Optional; DefaultParameterValue(null)>] ?AutoColorScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?CAuto: bool,
            [<Optional; DefaultParameterValue(null)>] ?CMax: float,
            [<Optional; DefaultParameterValue(null)>] ?CMid: float,
            [<Optional; DefaultParameterValue(null)>] ?CMin: float,
            [<Optional; DefaultParameterValue(null)>] ?ColorAxis: StyleParam.SubPlotId,
            [<Optional; DefaultParameterValue(null)>] ?Colorscale: StyleParam.Colorscale,
            [<Optional; DefaultParameterValue(null)>] ?ReverseScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ShowScale: bool,
            [<Optional; DefaultParameterValue(null)>] ?ColorBar: #DynamicObj
        ) =
        (fun (line: Line) ->
            Color |> DynObj.setValueOpt line "color"
            (Width, MultiWidth) |> DynObj.setSingleOrMultiOpt line "width"
            Shape |> DynObj.setValueOptBy line "shape" StyleParam.Shape.convert
            Smoothing |> DynObj.setValueOpt line "smoothing"
            Dash |> DynObj.setValueOptBy line "dash" StyleParam.DrawingStyle.convert
            OutlierColor |> DynObj.setValueOpt line "outliercolor"
            OutlierWidth |> DynObj.setValueOpt line "outlierwidth"
            AutoColorScale |> DynObj.setValueOpt line "autocolorscale"
            CAuto |> DynObj.setValueOpt line "cauto"
            CMax |> DynObj.setValueOpt line "cmax"
            CMid |> DynObj.setValueOpt line "cmid"
            CMin |> DynObj.setValueOpt line "cmin"
            Color |> DynObj.setValueOpt line "color"
            ColorAxis |> DynObj.setValueOptBy line "coloraxis" StyleParam.SubPlotId.convert
            Colorscale |> DynObj.setValueOptBy line "colorscale" StyleParam.Colorscale.convert
            ReverseScale |> DynObj.setValueOpt line "reversescale"
            ShowScale |> DynObj.setValueOpt line "showscale"
            ColorBar |> DynObj.setValueOpt line "colorbar"

            // out ->
            line)
