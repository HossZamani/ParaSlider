using Dynamo.Controls;
using Dynamo.Wpf;
using System.Windows.Controls;

namespace ParaSliderModel
{
    public class ParaSliderView : INodeViewCustomization<ParaSliderModel>
    {
        public void CustomizeView(ParaSliderModel model, NodeView nodeView)
        {
            var slider = new Slider();
            nodeView.inputGrid.Children.Add(slider);
            slider.DataContext = model;
        }

        public void Dispose()
        {
        }
    }
}
