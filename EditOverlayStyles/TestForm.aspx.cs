using System;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Drawing;
using ThinkGeo.MapSuite.Shapes;
using ThinkGeo.MapSuite.WebForms;

namespace EditOverlayStyles
{
    public partial class TestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Map1.MapBackground = new GeoSolidBrush(GeoColor.FromHtml("#E5E3DF"));
                Map1.CurrentExtent = new RectangleShape(-10779959, 3909739, -10777699, 3908399);
                Map1.MapUnit = GeographyUnit.Meter;

                Map1.MapTools.OverlaySwitcher.Enabled = true;
                Map1.MapTools.MouseCoordinate.Enabled = true;

                //Adds the Google Map as an overlay
                GoogleOverlay google = new GoogleOverlay("Google Map");
                google.GoogleMapType = GoogleMapType.Normal;
                Map1.CustomOverlays.Add(google);

                //Creates polygon feature to be added to the EditOverlay
                PolygonShape polygonShape = new PolygonShape();
                RingShape ringShape = new RingShape();
                ringShape.Vertices.Add(new Vertex(-10778968, 3909448));
                ringShape.Vertices.Add(new Vertex(-10778686, 3909443));
                ringShape.Vertices.Add(new Vertex(-10778691, 3909180));
                ringShape.Vertices.Add(new Vertex(-10778982, 3909175));
                ringShape.Vertices.Add(new Vertex(-10778968, 3909448));
                polygonShape.OuterRing = ringShape;

                Feature editFeature = new Feature(polygonShape);
                Map1.EditOverlay.Features.Add(editFeature);

                //Sets the properties so that the features can be only draggable.
                //Notice that we don't set the style here. We set the style in javascript in TestForm.aspx under the script tag.
                Map1.EditOverlay.TrackMode = TrackMode.Edit;
                Map1.EditOverlay.EditSettings.IsDraggable = true;
                Map1.EditOverlay.EditSettings.IsReshapable = false;
                Map1.EditOverlay.EditSettings.IsResizable = false;
                Map1.EditOverlay.EditSettings.IsRotatable = false;
            }
        }
    }
}
