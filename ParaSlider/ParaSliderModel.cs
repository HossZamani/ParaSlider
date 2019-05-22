using System;
using System.Collections.Generic;
using Dynamo.Graph.Nodes;
using ParaSliderFunctions;
using ProtoCore.AST.AssociativeAST;
using Autodesk.DesignScript.Geometry;

namespace ParaSliderModel
{
    [NodeName("Integer ParaSlider")]
    [NodeDescription("Parametric integer slider.")]
    [NodeCategory("ParaSlider")]
    [InPortNames("Min", "Max", "Step")]
    [InPortTypes("int", "int", "int")]
    [InPortDescriptions("Minimum", "Maximum", "Step")]
    [OutPortNames("")]
    [OutPortTypes("int")]
    [OutPortDescriptions("Selected Value")]
    public class ParaSliderModel : NodeModel
    {

        private int _sliderValue;
        public int SliderValue
        {
            get { return _sliderValue; }
            set
            {
                _sliderValue = value;
                RaisePropertyChanged("SliderValue");
                OnNodeModified(false);
            }
        }
        public ParaSliderModel()
        {
            RegisterAllPorts();
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            //if (!HasConnectedInput(0) || !HasConnectedInput(1))
            //{
            //    return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode()) };
            //}
            var sliderValue = AstFactory.BuildIntNode(SliderValue); //.BuildDoubleNode(SliderValue);
            //var functionCall =
            //  AstFactory.BuildFunctionCall(
            //    new Func<int, int, double, List<Rectangle>>(GridFunction.RectangularGrid),
            //    new List<AssociativeNode> { inputAstNodes[0], inputAstNodes[1], sliderValue });

            return new[] { sliderValue }; //new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), functionCall) };
        }
    }
}
