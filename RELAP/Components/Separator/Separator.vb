﻿'     
'    
'
'    This file is part of RIFGen.
'
'    RIFGen is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    RIFGen is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with RELAP.  If not, see <http://www.gnu.org/licenses/>.

Imports Microsoft.Msdn.Samples.GraphicObjects
'Imports RELAP.RELAP.Flowsheet.FlowSheetSolver

Namespace RELAP.SimulationObjects.UnitOps

    <System.Serializable()> Public Class Separator

        Inherits SimulationObjects_UnitOpBaseClass

        Protected m_dp As Nullable(Of Double)
        Protected m_DQ As Nullable(Of Double)
        Protected m_vol As Double = 0
        Protected m_tRes As Double = 0
        Enum Direction
            Inlet = 1
            Outlet = 2
        End Enum
        Enum StratificationModelEnum
            Dont_use_this_model
            upward_oriented_junction
            downward_oriented_junction
            centrally_located_junction
        End Enum
        Enum SeparatorOptionEnum
            Simple_Separator
            General_Electric_dryer_model_Separator
            General_Electric_two_stage_Separator
            General_Electric_three_stage_Separator
        End Enum

        Enum AreaChangeEnum
            No_Area_Change
            Smooth_Area_Change
            Full_Abrupt_Area_Change
            Partial_Abrupt_Area_Change
        End Enum

        Enum MomentumEquationEnum
            Two_velocity_Momentum_Equations
            Single_velocity_Momentum_Equations
        End Enum

        Enum MomentumFluxEnum
            To_and_From_Volume
            Only_From_Volume
            Only_To_Volume
            Do_not_use_Momentum_Flux
        End Enum

        Private _ThermoDynamicStates As ThermoDynamicStates
        Public Property ThermoDynamicStates() As ThermoDynamicStates
            Get
                Return _ThermoDynamicStates
            End Get
            Set(ByVal value As ThermoDynamicStates)
                _ThermoDynamicStates = value
            End Set
        End Property
        Private _SeparatorJunctionsGeometry As SeparatorJunctionsGeometry
        Public Property SeparatorJunctionsGeometry() As SeparatorJunctionsGeometry
            Get
                Return _SeparatorJunctionsGeometry
            End Get
            Set(ByVal value As SeparatorJunctionsGeometry)
                _SeparatorJunctionsGeometry = value
            End Set
        End Property

        Private _NumberofJunctions As Integer
        Public Property NumberofJunctions() As Integer
            Get
                Return _NumberofJunctions
            End Get
            Set(ByVal value As Integer)
                _NumberofJunctions = value
            End Set
        End Property

        Private _SeparatorOption As SeparatorOptionEnum
        Public Property SeparatorOption() As SeparatorOptionEnum
            Get
                Return _SeparatorOption
            End Get
            Set(ByVal value As SeparatorOptionEnum)
                _SeparatorOption = value
            End Set
        End Property

        Private _Noseparator As Integer
        Public Property Noseparator() As Integer
            Get
                Return _Noseparator
            End Get
            Set(ByVal value As Integer)
                _Noseparator = value
            End Set
        End Property

        Private m_flowarea As Double
        Public Property FlowArea() As Double
            Get
                Return m_flowarea
            End Get
            Set(ByVal value As Double)
                m_flowarea = value
            End Set
        End Property

        Private m_LengthofVolume As Double
        Public Property LengthofVolume() As Double
            Get
                Return m_LengthofVolume
            End Get
            Set(ByVal value As Double)
                m_LengthofVolume = value
            End Set
        End Property

        Private m_VolumeofVolume As Double
        Public Property VolumeofVolume() As Double
            Get
                Return m_VolumeofVolume
            End Get
            Set(ByVal value As Double)
                m_VolumeofVolume = value
            End Set
        End Property

        Private m_HydraulicDiameter As Double
        Public Property HydraulicDiameter() As Double
            Get
                Return m_HydraulicDiameter
            End Get
            Set(ByVal value As Double)
                m_HydraulicDiameter = value
            End Set
        End Property

        Private m_WallRoughness As Double
        Public Property WallRoughness() As Double
            Get
                Return m_WallRoughness
            End Get
            Set(ByVal value As Double)
                m_WallRoughness = value
            End Set
        End Property

        Private m_ElevationChange As Double
        Public Property ElevationChange() As Double
            Get
                Return m_ElevationChange
            End Get
            Set(ByVal value As Double)
                m_ElevationChange = value
            End Set
        End Property

        Private m_InclinationAngle As Double
        Public Property InclinationAngle() As Double
            Get
                Return m_InclinationAngle
            End Get
            Set(ByVal value As Double)
                m_InclinationAngle = value
            End Set
        End Property

        Private m_Azimuthalangle As Double
        Public Property Azimuthalangle() As Double
            Get
                Return m_Azimuthalangle
            End Get
            Set(ByVal value As Double)
                m_Azimuthalangle = value
            End Set
        End Property


        Private m_InitialLiquidVelocity As Double
        Public Property InitialLiquidVelocity() As Double
            Get
                Return m_InitialLiquidVelocity
            End Get
            Set(ByVal value As Double)
                m_InitialLiquidVelocity = value
            End Set
        End Property

        Private _pvterm As Boolean
        Public Property pvterm() As Boolean
            Get
                Return _pvterm
            End Get
            Set(ByVal value As Boolean)
                _pvterm = value
            End Set
        End Property

        Private _CCFL As Boolean
        Public Property CCFL() As Boolean
            Get
                Return _CCFL
            End Get
            Set(ByVal value As Boolean)
                _CCFL = value
            End Set
        End Property

        Private _StratificationModel As StratificationModelEnum
        Public Property StratificationModel() As StratificationModelEnum
            Get
                Return _StratificationModel
            End Get
            Set(ByVal value As StratificationModelEnum)
                _StratificationModel = value
            End Set
        End Property

        Private _chokingModel As Boolean
        Public Property chokingModel() As Boolean
            Get
                Return _chokingModel
            End Get
            Set(ByVal value As Boolean)
                _chokingModel = value
            End Set
        End Property

        Private _AreaChange As AreaChangeEnum
        Public Property AreaChange() As AreaChangeEnum
            Get
                Return _AreaChange
            End Get
            Set(ByVal value As AreaChangeEnum)
                _AreaChange = value
            End Set
        End Property

        Private _MomentumEquation As MomentumEquationEnum
        Public Property MomentumEquation() As MomentumEquationEnum
            Get
                Return _MomentumEquation
            End Get
            Set(ByVal value As MomentumEquationEnum)
                _MomentumEquation = value
            End Set
        End Property

        Private _MomentumFlux As MomentumFluxEnum
        Public Property MomentumFlux() As MomentumFluxEnum
            Get
                Return _MomentumFlux
            End Get
            Set(ByVal value As MomentumFluxEnum)
                _MomentumFlux = value
            End Set
        End Property

        Public Sub New(ByVal nome As String, ByVal descricao As String)

            MyBase.CreateNew()
            Me.m_ComponentName = nome
            Me.m_ComponentDescription = descricao
            Me._SeparatorJunctionsGeometry = New SeparatorJunctionsGeometry
            Me._ThermoDynamicStates = New ThermoDynamicStates
            Me._NumberofJunctions = 3
            Me.SeparatorOption = SeparatorOptionEnum.General_Electric_two_stage_Separator
            Me._Noseparator = 1
            Me.m_flowarea = 1.0
            Me.m_LengthofVolume = 2.0
            Me.m_VolumeofVolume = 0.0
            Me.m_Azimuthalangle = 0.0
            Me.m_InclinationAngle = 0.0
            Me.m_ElevationChange = 0.0
            Me.m_WallRoughness = 0.0
            Me.m_HydraulicDiameter = 0.0
            Me._pvterm = False
            Me._CCFL = False
            Me.StratificationModel = StratificationModelEnum.Dont_use_this_model
            Me._chokingModel = False
            Me.AreaChange = AreaChangeEnum.No_Area_Change
            Me.MomentumEquation = MomentumEquationEnum.Two_velocity_Momentum_Equations
            Me.MomentumFlux = MomentumFluxEnum.To_and_From_Volume
            Me.FillNodeItems()
            Me.QTFillNodeItems()
        End Sub

        Public Property ResidenceTime() As Double
            Get
                Return m_tRes
            End Get
            Set(ByVal value As Double)
                m_tRes = value
            End Set
        End Property

        Public Property DeltaP() As Nullable(Of Double)
            Get
                Return m_dp
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_dp = value
            End Set
        End Property

        Public Property DeltaQ() As Nullable(Of Double)
            Get
                Return m_DQ
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_DQ = value
            End Set
        End Property

        Public Overrides Function Calculate(Optional ByVal args As Object = Nothing) As Integer


            'Dim form As Global.RELAP.FormFlowsheet = My.Application.ActiveSimulation
            'Dim Ti, Pi, Hi, Wi, rho_li, qli, qvi, ei, ein, P2, Q As Double

            'qvi = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(2).SPMProperties.volumetric_flow.GetValueOrDefault.ToString

            'Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            'If qvi > 0 Then
            '    'Call function to calculate flowsheet
            '    With objargs
            '        .Calculado = False
            '        .Nome = Me.Nome
            '        .Tipo = TipoObjeto.Tank
            '    End With
            '    CalculateFlowsheet(FlowSheet, objargs, Nothing)
            '    Throw New Exception(RELAP.App.GetLocalString("Existeumafasevaporna2"))
            'ElseIf Not Me.GraphicObject.OutputConnectors(0).IsAttached Then
            '    'Call function to calculate flowsheet
            '    With objargs
            '        .Calculado = False
            '        .Nome = Me.Nome
            '        .Tipo = TipoObjeto.Tank
            '    End With
            '    CalculateFlowsheet(FlowSheet, objargs, Nothing)
            '    Throw New Exception(RELAP.App.GetLocalString("Verifiqueasconexesdo"))
            'ElseIf Not Me.GraphicObject.InputConnectors(0).IsAttached Then
            '    'Call function to calculate flowsheet
            '    With objargs
            '        .Calculado = False
            '        .Nome = Me.Nome
            '        .Tipo = TipoObjeto.Tank
            '    End With
            '    CalculateFlowsheet(FlowSheet, objargs, Nothing)
            '    Throw New Exception(RELAP.App.GetLocalString("Verifiqueasconexesdo"))
            'End If

            'Me.PropertyPackage.CurrentMaterialStream = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name)
            'Ti = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.temperature.GetValueOrDefault.ToString
            'Pi = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.pressure.GetValueOrDefault.ToString
            'rho_li = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(1).SPMProperties.density.GetValueOrDefault.ToString
            'qli = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(1).SPMProperties.volumetric_flow.GetValueOrDefault.ToString
            'Hi = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.enthalpy.GetValueOrDefault.ToString
            'Wi = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.massflow.GetValueOrDefault.ToString
            'Q = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.volumetric_flow.GetValueOrDefault
            'ei = Hi * Wi
            'ein = ei

            'P2 = Pi - Me.DeltaP.GetValueOrDefault

            ''Atribuir valores à corrente de matéria conectada à jusante
            'With form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.OutputConnectors(0).AttachedConnector.AttachedTo.Name)
            '    .Fases(0).SPMProperties.temperature = Ti
            '    .Fases(0).SPMProperties.pressure = P2
            '    .Fases(0).SPMProperties.enthalpy = Hi
            '    Dim comp As RELAP.ClassesBasicasTermodinamica.Substancia
            '    Dim i As Integer = 0
            '    For Each comp In .Fases(0).Componentes.Values
            '        comp.FracaoMolar = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).Componentes(comp.Nome).FracaoMolar
            '        comp.FracaoMassica = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).Componentes(comp.Nome).FracaoMassica
            '        i += 1
            '    Next
            '    .Fases(0).SPMProperties.massflow = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.massflow.GetValueOrDefault
            'End With

            'Me.ResidenceTime = Me.Volume / Q

            ''Call function to calculate flowsheet
            'With objargs
            '    .Calculado = True
            '    .Nome = Me.Nome
            '    .Tipo = TipoObjeto.Tank
            'End With

            'form.CalculationQueue.Enqueue(objargs)
            Return 0
        End Function

        Public Overrides Function DeCalculate() As Integer

            'Dim form As Global.RELAP.FormFlowsheet = My.Application.ActiveSimulation

            'If Me.GraphicObject.OutputConnectors(0).IsAttached Then

            '    'Zerar valores da corrente de matéria conectada a jusante
            '    With form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.OutputConnectors(0).AttachedConnector.AttachedTo.Name)
            '        .Fases(0).SPMProperties.temperature = Nothing
            '        .Fases(0).SPMProperties.pressure = Nothing
            '        .Fases(0).SPMProperties.molarfraction = 1
            '        .Fases(0).SPMProperties.massfraction = 1
            '        .Fases(0).SPMProperties.enthalpy = Nothing
            '        Dim comp As RELAP.ClassesBasicasTermodinamica.Substancia
            '        Dim i As Integer = 0
            '        For Each comp In .Fases(0).Componentes.Values
            '            comp.FracaoMolar = 0
            '            comp.FracaoMassica = 0
            '            i += 1
            '        Next
            '        .Fases(0).SPMProperties.massflow = Nothing
            '        .Fases(0).SPMProperties.molarflow = Nothing
            '        .GraphicObject.Calculated = False
            '    End With

            'End If

            ''Call function to calculate flowsheet
            'Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            'With objargs
            '    .Calculado = False
            '    .Nome = Me.Nome
            '    .Tag = Me.GraphicObject.Tag
            '    .Tipo = TipoObjeto.Tank
            'End With

            'form.CalculationQueue.Enqueue(objargs)
            Return 0
        End Function

        Public Overloads Overrides Sub UpdatePropertyNodes(ByVal su As SistemasDeUnidades.Unidades, ByVal nf As String)

            Dim Conversor As New RELAP.SistemasDeUnidades.Conversor
            If Me.NodeTableItems Is Nothing Then
                Me.NodeTableItems = New System.Collections.Generic.Dictionary(Of Integer, RELAP.Outros.NodeItem)
                Me.FillNodeItems()
            End If

            For Each nti As Outros.NodeItem In Me.NodeTableItems.Values
                nti.Value = GetPropertyValue(nti.Text, FlowSheet.Options.SelectedUnitSystem)
                nti.Unit = GetPropertyUnit(nti.Text, FlowSheet.Options.SelectedUnitSystem)
            Next

            If Me.QTNodeTableItems Is Nothing Then
                Me.QTNodeTableItems = New System.Collections.Generic.Dictionary(Of Integer, RELAP.Outros.NodeItem)
                Me.QTFillNodeItems()
            End If

            With Me.QTNodeTableItems

                Dim valor As String

                If Me.DeltaP.HasValue Then
                    valor = Format(Conversor.ConverterDoSI(su.spmp_deltaP, Me.DeltaP), nf)
                Else
                    valor = RELAP.App.GetLocalString("NC")
                End If
                .Item(0).Value = valor
                .Item(0).Unit = su.spmp_deltaP

                If Me.DeltaQ.HasValue Then
                    valor = Format(Conversor.ConverterDoSI(su.spmp_heatflow, Me.DeltaQ), nf)
                Else
                    valor = RELAP.App.GetLocalString("NC")
                End If
                .Item(1).Value = valor
                .Item(1).Unit = su.spmp_heatflow

            End With


        End Sub

        Public Overrides Sub QTFillNodeItems()

            With Me.QTNodeTableItems

                .Clear()

                .Add(0, New RELAP.Outros.NodeItem("DP", "", "", 0, 0, ""))
                .Add(1, New RELAP.Outros.NodeItem("A/R", "", "", 1, 0, ""))

            End With

        End Sub

        Public Overrides Sub PopulatePropertyGrid(ByRef pgrid As PropertyGridEx.PropertyGridEx, ByVal su As SistemasDeUnidades.Unidades)

            Dim Conversor As New RELAP.SistemasDeUnidades.Conversor

            With pgrid

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True
                .Item.Clear()

                MyBase.PopulatePropertyGrid(pgrid, su)
                'input connector added
                Dim ent, saida, energ As String
                If Me.GraphicObject.InputConnectors(0).IsAttached = True Then
                    ent = Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Tag
                Else
                    ent = ""
                End If
                'output connector added
                If Me.GraphicObject.OutputConnectors(0).IsAttached = True Then
                    saida = Me.GraphicObject.OutputConnectors(0).AttachedConnector.AttachedTo.Tag
                Else
                    saida = ""
                End If
                'energy connector added
                If Me.GraphicObject.EnergyConnector.IsAttached = True Then
                    energ = Me.GraphicObject.EnergyConnector.AttachedConnector.AttachedTo.Tag
                Else
                    energ = ""
                End If
                'inlet stream , connections
                '.Item.Add(RELAP.App.GetLocalString("Correntedeentrada"), ent, False, RELAP.App.GetLocalString("Conexes1"), "", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .CustomEditor = New RELAP.Editors.Streams.UIInputMSSelector

                'End With
                ''outlet stream, connections
                '.Item.Add(RELAP.App.GetLocalString("Correntedesada"), saida, False, RELAP.App.GetLocalString("Conexes1"), "", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .CustomEditor = New RELAP.Editors.Streams.UIOutputMSSelector
                'End With
                ' pressure drop, Calculation parameters, Pressure drop in the tank
                Dim valor = Format(Conversor.ConverterDoSI(su.spmp_deltaP, Me.DeltaP.GetValueOrDefault), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(RELAP.App.GetLocalString("Quedadepresso"), su.spmp_deltaP), valor, False, "Parameters", RELAP.App.GetLocalString("Quedadepressoaplicad5"), True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Nullable(Of Double))
                'End With
                ''desi kaam

                ''.Item.Add("Flow Area", FlowArea())



                ' '''''''''''''

                'valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.FromComponent), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT("From Component", su.no_unit), valor, False, "Parameters", "From Component", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.ToComponent), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT("To Component", su.no_unit), valor, False, "Parameters", "To component", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With
                valor = Format(Me.NumberofJunctions, FlowSheet.Options.NumberFormat)
                .Item.Add(("Number of Junctions"), Me, "NumberofJunctions", True, "1.Parameters", "Number of Junctions", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                .Item.Add("Separator Option", Me, "SeparatorOption", False, "1.Parameters", "Separator Option", True)

                valor = Format(Me.Noseparator, FlowSheet.Options.NumberFormat)
                .Item.Add(("Number of Separator Components"), Me, "Noseparator", False, "1.Parameters", "Number of Separator Components represented by this RELAP5 component", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With
  valor = Format(Me.FlowArea, FlowSheet.Options.NumberFormat)
                'Tank Volume,Calculation parameters, Tank Volume
                .Item.Add("Volume Flow Area", valor, False, "1.Parameters", "Volume Flow Area", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.LengthofVolume, FlowSheet.Options.NumberFormat)
                .Item.Add("Length of Volume", valor, False, "1.Parameters", "Length of Volume", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.VolumeofVolume, FlowSheet.Options.NumberFormat)
                .Item.Add("Volume of Volume", valor, False, "1.Parameters", "Volume of Volume", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.Azimuthalangle, FlowSheet.Options.NumberFormat)
                .Item.Add("Azimuthal Angle", valor, False, "1.Parameters", "Azimuthal Angle", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.InclinationAngle, FlowSheet.Options.NumberFormat)
                .Item.Add("Inclination Angle", valor, False, "1.Parameters", "Inclination Angle", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.ElevationChange, FlowSheet.Options.NumberFormat)
                .Item.Add("Elevation Change", valor, False, "1.Parameters", "Elevation Change", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.WallRoughness, FlowSheet.Options.NumberFormat)
                .Item.Add("Wall Roughness", valor, False, "1.Parameters", "Wall Roughness", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.HydraulicDiameter, FlowSheet.Options.NumberFormat)
                .Item.Add("Hydraulic Diameter", valor, False, "1.Parameters", "Hydraulic Diameter", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                .Item.Add("Thermo Dynamic States", Me, "ThermoDynamicStates", False, "1.Parameters", "Thermo Dynamic States", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(ThermoDynamicState)
                    .CustomEditor = New RELAP.Editors.UIThermoDynamicStatesEditor
                End With

                .Item.Add("Set Separator Junctions Geometry", Me, "SeparatorJunctionsGeometry", False, "1.Parameters", "Set Separator Junctions Geometry", True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(SeparatorJunctionsGeometry)
                    .CustomEditor = New RELAP.Editors.UISeparatorEditor
                End With


                .Item.Add("Area Change", Me, "AreaChange", False, "2. Junction Control Flags", "Area Change Options", True)

                .Item.Add("Momentum Equation", Me, "MomentumEquation", False, "2. Junction Control Flags", "Specify homogenius or nonhomogenius", True)

                .Item.Add("Momentum Flux Options", Me, "MomentumFlux", False, "2. Junction Control Flags", "", True)




            End With

        End Sub

        Public Overrides Function GetPropertyValue(ByVal prop As String, Optional ByVal su As SistemasDeUnidades.Unidades = Nothing) As Object

            If su Is Nothing Then su = New RELAP.SistemasDeUnidades.UnidadesSI
            Dim cv As New RELAP.SistemasDeUnidades.Conversor
            Dim value As Double = 0
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            Select Case propidx

                Case 0
                    'PROP_TK_0	Pressure Drop
                    value = cv.ConverterDoSI(su.spmp_deltaP, Me.DeltaP.GetValueOrDefault)

            End Select

            Return value

        End Function



        Public Overloads Overrides Function GetProperties(ByVal proptype As SimulationObjects_BaseClass.PropertyType) As String()
            Dim i As Integer = 0
            Dim proplist As New ArrayList
            Select Case proptype
                Case PropertyType.RW
                    For i = 2 To 2
                        proplist.Add("PROP_TK_" + CStr(i))
                    Next
                Case PropertyType.RW
                    For i = 0 To 2
                        proplist.Add("PROP_TK_" + CStr(i))
                    Next
                Case PropertyType.WR
                    For i = 0 To 1
                        proplist.Add("PROP_TK_" + CStr(i))
                    Next
                Case PropertyType.ALL
                    For i = 0 To 2
                        proplist.Add("PROP_TK_" + CStr(i))
                    Next
            End Select
            Return proplist.ToArray(GetType(System.String))
            proplist = Nothing
        End Function

        Public Overrides Function SetPropertyValue(ByVal prop As String, ByVal propval As Object, Optional ByVal su As RELAP.SistemasDeUnidades.Unidades = Nothing) As Object
            If su Is Nothing Then su = New RELAP.SistemasDeUnidades.UnidadesSI
            Dim cv As New RELAP.SistemasDeUnidades.Conversor
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            Select Case propidx
                Case 0
                    'PROP_TK_0	Pressure Drop
                    Me.DeltaP = cv.ConverterParaSI(su.spmp_deltaP, propval)
                Case 1
                    'PROP_TK_1	Volume
                    Me.DeltaP = cv.ConverterParaSI(su.volume, propval)
            End Select
            Return 1
        End Function

        Public Overrides Function GetPropertyUnit(ByVal prop As String, Optional ByVal su As SistemasDeUnidades.Unidades = Nothing) As Object
            If su Is Nothing Then su = New RELAP.SistemasDeUnidades.UnidadesSI
            Dim cv As New RELAP.SistemasDeUnidades.Conversor
            Dim value As String = ""
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            Select Case propidx

                Case 0
                    'PROP_TK_0	Pressure Drop
                    value = su.spmp_deltaP

                Case 1
                    'PROP_TK_1	Volume
                    value = su.volume

                Case 2
                    'PROP_TK_2	Residence Time
                    value = su.time

            End Select

            Return value
        End Function
    End Class

End Namespace



