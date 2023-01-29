// Decompiled with JetBrains decompiler
// Type: Painter.MainForm
// Assembly: Painter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6C7491-0546-43BD-B8DF-DE31170BE9D0
// Assembly location: C:\Users\kevin\Downloads\Painter_demo\Painter_demo\Painter.exe

using Globe.Graphics.Bidimensional.Base;
using Globe.Graphics.Bidimensional.Common;
using Globe.Xml.Serialization;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Painter
{
  public class MainForm : Form
  {
    private IContainer components;
    private MenuStrip _menu;
    private ToolStripMenuItem _menuFile;
    private SplitContainer _mainSplitContainer;
    private ToolStrip _toolBar;
    private StatusStrip _statusBar;
    private DrawingPanel _drawingPanel;
    private Panel _panel;
    private ToolStripMenuItem _shapesBase;
    private ToolStripMenuItem _baseRectangle;
    private ToolStripMenuItem _baseEllipse;
    private ToolStripMenuItem _menuTools;
    private ToolStripMenuItem _toolSelect;
    private ToolStripMenuItem _toolsPointer;
    private ToolStripMenuItem _toolsDrawing;
    private ToolStripMenuItem _drawingRectangle;
    private ToolStripMenuItem _drawingEllipse;
    private ToolStripMenuItem _toolsMove;
    private ToolStripMenuItem _toolsRotate;
    private ToolStripMenuItem _toolsMultiSelect;
    private ToolStripMenuItem _toolsResize;
    private ContextMenuStrip _contextMenu;
    private ToolStripMenuItem _contextLayout;
    private ToolStripMenuItem _contextGroup;
    private ToolStripMenuItem _contextUngroup;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem _contextAlignLefts;
    private ToolStripMenuItem _contextAlignRights;
    private ToolStripMenuItem _contextAlignTops;
    private ToolStripMenuItem _contextAlignBottoms;
    private ToolStripMenuItem _contextMakeSameWidth;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem _contextMakeSameHeight;
    private ToolStripMenuItem _contextMakeSameSize;
    private ToolStripMenuItem _menuLayout;
    private ToolStripMenuItem _layoutGroup;
    private ToolStripMenuItem _layoutUngroup;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem _layoutAlignLefts;
    private ToolStripMenuItem _layoutAlignRights;
    private ToolStripMenuItem _layoutAlignTops;
    private ToolStripMenuItem _layoutAlignBottoms;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem _layoutMakeSameWidth;
    private ToolStripMenuItem _layoutMakeSameHeight;
    private ToolStripMenuItem _layoutMakeSameSize;
    private Panel _scrollingPanel;
    private ToolStripMenuItem _menuEdit;
    private ToolStripMenuItem _menuView;
    private ToolStripMenuItem _viewZoom;
    private ToolStripMenuItem _zoomZoomIn;
    private ToolStripMenuItem _zoomZoomOut;
    private ToolStripMenuItem _menuOpen;
    private ToolStripMenuItem _menuSave;
    private ToolStripMenuItem _menuSaveAs;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripMenuItem _toolsDeform;
    private ToolStripMenuItem _editDelete;
    private ToolStripMenuItem _editUndo;
    private ToolStripMenuItem _editRedo;
    private ToolStripSeparator toolStripSeparator7;
    private ToolStripMenuItem _editCut;
    private ToolStripMenuItem _editCopy;
    private ToolStripMenuItem _editPaste;
    private ToolStripMenuItem _drawingLine;
    private ToolStripSeparator toolStripSeparator8;
    private ToolStripMenuItem _toolsMirror;
    private ToolStripMenuItem _toolsHorizontalLeft;
    private ToolStripMenuItem _toolsVerticalTop;
    private ToolStripMenuItem _toolsHorizontalRight;
    private ToolStripMenuItem _toolsVerticalBottom;
    private ToolStripMenuItem _drawingPolygon;
    private TabControl _tab;
    private TabPage _tabPageProperties;
    private PropertyGrid _propertyGrid;
    private ToolStripSeparator toolStripSeparator9;
    private ToolStripSeparator toolStripSeparator10;
    private ToolStripMenuItem _editSelectAll;
    private TabPage _tabPageEvents;
    private Button _btnReset;
    private ListBox _listEvents;
    private ToolStripMenuItem _drawingSloppedLine;
    private ToolStripMenuItem _drawingText;
    private OpenFileDialog _openDialog;
    private SaveFileDialog _saveDialog;
    private TabPage _tabPagePanelProperties;
    private PropertyGrid _propertyGridPanel;
    private ToolStripMenuItem _toolsCopyPoint;
    private ToolStripMenuItem _drawingFreeLine;
    private ToolStripSeparator toolStripSeparator11;
    private ToolStripMenuItem bringToFrontToolStripMenuItem;
    private ToolStripMenuItem sendToBackToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator12;
    private ToolStripMenuItem bringToFrontToolStripMenuItem1;
    private ToolStripMenuItem sendToBackToolStripMenuItem1;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      Globe.Graphics.Bidimensional.Common.Select select = new Globe.Graphics.Bidimensional.Common.Select();
      this._menu = new MenuStrip();
      this._menuFile = new ToolStripMenuItem();
      this._menuOpen = new ToolStripMenuItem();
      this._menuSave = new ToolStripMenuItem();
      this._menuSaveAs = new ToolStripMenuItem();
      this._menuEdit = new ToolStripMenuItem();
      this._editUndo = new ToolStripMenuItem();
      this._editRedo = new ToolStripMenuItem();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this._editCut = new ToolStripMenuItem();
      this._editCopy = new ToolStripMenuItem();
      this._editPaste = new ToolStripMenuItem();
      this._editDelete = new ToolStripMenuItem();
      this.toolStripSeparator10 = new ToolStripSeparator();
      this._editSelectAll = new ToolStripMenuItem();
      this._menuView = new ToolStripMenuItem();
      this._viewZoom = new ToolStripMenuItem();
      this._zoomZoomIn = new ToolStripMenuItem();
      this._zoomZoomOut = new ToolStripMenuItem();
      this._menuTools = new ToolStripMenuItem();
      this._toolsDrawing = new ToolStripMenuItem();
      this._drawingRectangle = new ToolStripMenuItem();
      this._drawingLine = new ToolStripMenuItem();
      this._drawingEllipse = new ToolStripMenuItem();
      this._drawingPolygon = new ToolStripMenuItem();
      this._drawingSloppedLine = new ToolStripMenuItem();
      this._drawingFreeLine = new ToolStripMenuItem();
      this._drawingText = new ToolStripMenuItem();
      this.toolStripSeparator9 = new ToolStripSeparator();
      this._toolsMirror = new ToolStripMenuItem();
      this._toolsHorizontalLeft = new ToolStripMenuItem();
      this._toolsHorizontalRight = new ToolStripMenuItem();
      this._toolsVerticalTop = new ToolStripMenuItem();
      this._toolsVerticalBottom = new ToolStripMenuItem();
      this.toolStripSeparator8 = new ToolStripSeparator();
      this._toolsPointer = new ToolStripMenuItem();
      this._toolSelect = new ToolStripMenuItem();
      this._toolsMultiSelect = new ToolStripMenuItem();
      this._toolsResize = new ToolStripMenuItem();
      this._toolsMove = new ToolStripMenuItem();
      this._toolsRotate = new ToolStripMenuItem();
      this._toolsDeform = new ToolStripMenuItem();
      this._toolsCopyPoint = new ToolStripMenuItem();
      this._menuLayout = new ToolStripMenuItem();
      this._layoutGroup = new ToolStripMenuItem();
      this._layoutUngroup = new ToolStripMenuItem();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this._layoutAlignLefts = new ToolStripMenuItem();
      this._layoutAlignRights = new ToolStripMenuItem();
      this._layoutAlignTops = new ToolStripMenuItem();
      this._layoutAlignBottoms = new ToolStripMenuItem();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this._layoutMakeSameWidth = new ToolStripMenuItem();
      this._layoutMakeSameHeight = new ToolStripMenuItem();
      this._layoutMakeSameSize = new ToolStripMenuItem();
      this.toolStripSeparator11 = new ToolStripSeparator();
      this.bringToFrontToolStripMenuItem = new ToolStripMenuItem();
      this.sendToBackToolStripMenuItem = new ToolStripMenuItem();
      this._shapesBase = new ToolStripMenuItem();
      this._baseRectangle = new ToolStripMenuItem();
      this._baseEllipse = new ToolStripMenuItem();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this._mainSplitContainer = new SplitContainer();
      this._scrollingPanel = new Panel();
      this._drawingPanel = new DrawingPanel();
      this._tab = new TabControl();
      this._tabPageProperties = new TabPage();
      this._propertyGrid = new PropertyGrid();
      this._tabPagePanelProperties = new TabPage();
      this._propertyGridPanel = new PropertyGrid();
      this._tabPageEvents = new TabPage();
      this._btnReset = new Button();
      this._listEvents = new ListBox();
      this._toolBar = new ToolStrip();
      this._statusBar = new StatusStrip();
      this._panel = new Panel();
      this._contextMenu = new ContextMenuStrip(this.components);
      this._contextLayout = new ToolStripMenuItem();
      this._contextGroup = new ToolStripMenuItem();
      this._contextUngroup = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this._contextAlignLefts = new ToolStripMenuItem();
      this._contextAlignRights = new ToolStripMenuItem();
      this._contextAlignTops = new ToolStripMenuItem();
      this._contextAlignBottoms = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this._contextMakeSameWidth = new ToolStripMenuItem();
      this._contextMakeSameHeight = new ToolStripMenuItem();
      this._contextMakeSameSize = new ToolStripMenuItem();
      this._openDialog = new OpenFileDialog();
      this._saveDialog = new SaveFileDialog();
      this.toolStripSeparator12 = new ToolStripSeparator();
      this.bringToFrontToolStripMenuItem1 = new ToolStripMenuItem();
      this.sendToBackToolStripMenuItem1 = new ToolStripMenuItem();
      this._menu.SuspendLayout();
      this._mainSplitContainer.Panel1.SuspendLayout();
      this._mainSplitContainer.Panel2.SuspendLayout();
      this._mainSplitContainer.SuspendLayout();
      this._scrollingPanel.SuspendLayout();
      this._tab.SuspendLayout();
      this._tabPageProperties.SuspendLayout();
      this._tabPagePanelProperties.SuspendLayout();
      this._tabPageEvents.SuspendLayout();
      this._panel.SuspendLayout();
      this._contextMenu.SuspendLayout();
      this.SuspendLayout();
      this._menu.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this._menuFile,
        (ToolStripItem) this._menuEdit,
        (ToolStripItem) this._menuView,
        (ToolStripItem) this._menuTools,
        (ToolStripItem) this._menuLayout
      });
      this._menu.Location = new Point(0, 0);
      this._menu.Name = "_menu";
      this._menu.Size = new Size(611, 24);
      this._menu.TabIndex = 0;
      this._menu.Text = "menuStrip1";
      this._menuFile.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this._menuOpen,
        (ToolStripItem) this._menuSave,
        (ToolStripItem) this._menuSaveAs
      });
      this._menuFile.Name = "_menuFile";
      this._menuFile.Size = new Size(35, 20);
      this._menuFile.Text = "&File";
      this._menuOpen.Name = "_menuOpen";
      this._menuOpen.Size = new Size(125, 22);
      this._menuOpen.Text = "Open...";
      this._menuOpen.Click += new EventHandler(this._menuOpen_Click);
      this._menuSave.Name = "_menuSave";
      this._menuSave.Size = new Size(125, 22);
      this._menuSave.Text = "Save...";
      this._menuSave.Click += new EventHandler(this._menuSave_Click);
      this._menuSaveAs.Enabled = false;
      this._menuSaveAs.Name = "_menuSaveAs";
      this._menuSaveAs.Size = new Size(125, 22);
      this._menuSaveAs.Text = "Save As...";
      this._menuEdit.DropDownItems.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this._editUndo,
        (ToolStripItem) this._editRedo,
        (ToolStripItem) this.toolStripSeparator7,
        (ToolStripItem) this._editCut,
        (ToolStripItem) this._editCopy,
        (ToolStripItem) this._editPaste,
        (ToolStripItem) this._editDelete,
        (ToolStripItem) this.toolStripSeparator10,
        (ToolStripItem) this._editSelectAll
      });
      this._menuEdit.Name = "_menuEdit";
      this._menuEdit.Size = new Size(37, 20);
      this._menuEdit.Text = "&Edit";
      this._editUndo.Name = "_editUndo";
      this._editUndo.ShortcutKeys = Keys.Z | Keys.Control;
      this._editUndo.Size = new Size(156, 22);
      this._editUndo.Text = "Undo";
      this._editUndo.Click += new EventHandler(this._editUndo_Click);
      this._editRedo.Name = "_editRedo";
      this._editRedo.ShortcutKeys = Keys.Y | Keys.Control;
      this._editRedo.Size = new Size(156, 22);
      this._editRedo.Text = "Redo";
      this._editRedo.Click += new EventHandler(this._editRedo_Click);
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(153, 6);
      this._editCut.Name = "_editCut";
      this._editCut.ShortcutKeys = Keys.X | Keys.Control;
      this._editCut.Size = new Size(156, 22);
      this._editCut.Text = "Cut";
      this._editCut.Click += new EventHandler(this._editCut_Click);
      this._editCopy.Name = "_editCopy";
      this._editCopy.ShortcutKeys = Keys.C | Keys.Control;
      this._editCopy.Size = new Size(156, 22);
      this._editCopy.Text = "Copy";
      this._editCopy.Click += new EventHandler(this._editCopy_Click);
      this._editPaste.Name = "_editPaste";
      this._editPaste.ShortcutKeys = Keys.V | Keys.Control;
      this._editPaste.Size = new Size(156, 22);
      this._editPaste.Text = "Paste";
      this._editPaste.Click += new EventHandler(this._editPaste_Click);
      this._editDelete.Name = "_editDelete";
      this._editDelete.ShortcutKeys = Keys.Delete;
      this._editDelete.Size = new Size(156, 22);
      this._editDelete.Text = "Delete";
      this._editDelete.Click += new EventHandler(this._editDelete_Click);
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new Size(153, 6);
      this._editSelectAll.Name = "_editSelectAll";
      this._editSelectAll.ShortcutKeys = Keys.A | Keys.Control;
      this._editSelectAll.Size = new Size(156, 22);
      this._editSelectAll.Text = "Select All";
      this._editSelectAll.Click += new EventHandler(this._editSelectAll_Click);
      this._menuView.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this._viewZoom
      });
      this._menuView.Name = "_menuView";
      this._menuView.Size = new Size(41, 20);
      this._menuView.Text = "&View";
      this._viewZoom.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this._zoomZoomIn,
        (ToolStripItem) this._zoomZoomOut
      });
      this._viewZoom.Name = "_viewZoom";
      this._viewZoom.Size = new Size(100, 22);
      this._viewZoom.Text = "Zoom";
      this._zoomZoomIn.Name = "_zoomZoomIn";
      this._zoomZoomIn.Size = new Size(121, 22);
      this._zoomZoomIn.Text = "Zoom In";
      this._zoomZoomIn.Click += new EventHandler(this._zoomZoomIn_Click);
      this._zoomZoomOut.Name = "_zoomZoomOut";
      this._zoomZoomOut.Size = new Size(121, 22);
      this._zoomZoomOut.Text = "Zoom Out";
      this._zoomZoomOut.Click += new EventHandler(this._zoomZoomOut_Click);
      this._menuTools.DropDownItems.AddRange(new ToolStripItem[12]
      {
        (ToolStripItem) this._toolsDrawing,
        (ToolStripItem) this.toolStripSeparator9,
        (ToolStripItem) this._toolsMirror,
        (ToolStripItem) this.toolStripSeparator8,
        (ToolStripItem) this._toolsPointer,
        (ToolStripItem) this._toolSelect,
        (ToolStripItem) this._toolsMultiSelect,
        (ToolStripItem) this._toolsResize,
        (ToolStripItem) this._toolsMove,
        (ToolStripItem) this._toolsRotate,
        (ToolStripItem) this._toolsDeform,
        (ToolStripItem) this._toolsCopyPoint
      });
      this._menuTools.Name = "_menuTools";
      this._menuTools.Size = new Size(44, 20);
      this._menuTools.Text = "Tools";
      this._toolsDrawing.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this._drawingRectangle,
        (ToolStripItem) this._drawingLine,
        (ToolStripItem) this._drawingEllipse,
        (ToolStripItem) this._drawingPolygon,
        (ToolStripItem) this._drawingSloppedLine,
        (ToolStripItem) this._drawingFreeLine,
        (ToolStripItem) this._drawingText
      });
      this._toolsDrawing.Name = "_toolsDrawing";
      this._toolsDrawing.Size = new Size(126, 22);
      this._toolsDrawing.Text = "Drawing";
      this._drawingRectangle.Name = "_drawingRectangle";
      this._drawingRectangle.Size = new Size(134, 22);
      this._drawingRectangle.Text = "Rectangle";
      this._drawingRectangle.Click += new EventHandler(this._drawingRectangle_Click);
      this._drawingLine.Name = "_drawingLine";
      this._drawingLine.Size = new Size(134, 22);
      this._drawingLine.Text = "Line";
      this._drawingLine.Click += new EventHandler(this._drawingLine_Click);
      this._drawingEllipse.Name = "_drawingEllipse";
      this._drawingEllipse.Size = new Size(134, 22);
      this._drawingEllipse.Text = "Ellipse";
      this._drawingEllipse.Click += new EventHandler(this._drawingEllipse_Click);
      this._drawingPolygon.Name = "_drawingPolygon";
      this._drawingPolygon.Size = new Size(134, 22);
      this._drawingPolygon.Text = "Polygon";
      this._drawingPolygon.Click += new EventHandler(this._drawingPolygon_Click);
      this._drawingSloppedLine.Name = "_drawingSloppedLine";
      this._drawingSloppedLine.Size = new Size(134, 22);
      this._drawingSloppedLine.Text = "Slopped Line";
      this._drawingSloppedLine.Click += new EventHandler(this._drawingSloppedLine_Click);
      this._drawingFreeLine.Name = "_drawingFreeLine";
      this._drawingFreeLine.Size = new Size(134, 22);
      this._drawingFreeLine.Text = "Free Line";
      this._drawingFreeLine.Click += new EventHandler(this._drawingFreeLine_Click);
      this._drawingText.Name = "_drawingText";
      this._drawingText.Size = new Size(134, 22);
      this._drawingText.Text = "Text";
      this._drawingText.Click += new EventHandler(this._drawingText_Click);
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new Size(123, 6);
      this._toolsMirror.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this._toolsHorizontalLeft,
        (ToolStripItem) this._toolsHorizontalRight,
        (ToolStripItem) this._toolsVerticalTop,
        (ToolStripItem) this._toolsVerticalBottom
      });
      this._toolsMirror.Name = "_toolsMirror";
      this._toolsMirror.Size = new Size(126, 22);
      this._toolsMirror.Text = "Mirror";
      this._toolsHorizontalLeft.Name = "_toolsHorizontalLeft";
      this._toolsHorizontalLeft.Size = new Size(150, 22);
      this._toolsHorizontalLeft.Text = "Horizontal Left";
      this._toolsHorizontalLeft.Click += new EventHandler(this._toolsHorizontalLeft_Click);
      this._toolsHorizontalRight.Name = "_toolsHorizontalRight";
      this._toolsHorizontalRight.Size = new Size(150, 22);
      this._toolsHorizontalRight.Text = "Horizontal Right";
      this._toolsHorizontalRight.Click += new EventHandler(this._toolsHorizontalRight_Click);
      this._toolsVerticalTop.Name = "_toolsVerticalTop";
      this._toolsVerticalTop.Size = new Size(150, 22);
      this._toolsVerticalTop.Text = "Vertical Top";
      this._toolsVerticalTop.Click += new EventHandler(this._toolsVerticalTop_Click);
      this._toolsVerticalBottom.Name = "_toolsVerticalBottom";
      this._toolsVerticalBottom.Size = new Size(150, 22);
      this._toolsVerticalBottom.Text = "Vertical Bottom";
      this._toolsVerticalBottom.Click += new EventHandler(this._toolsVerticalBottom_Click);
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new Size(123, 6);
      this._toolsPointer.Name = "_toolsPointer";
      this._toolsPointer.Size = new Size(126, 22);
      this._toolsPointer.Text = "Pointer";
      this._toolsPointer.Click += new EventHandler(this._toolsPointer_Click);
      this._toolSelect.Name = "_toolSelect";
      this._toolSelect.Size = new Size(126, 22);
      this._toolSelect.Text = "Select";
      this._toolSelect.Click += new EventHandler(this._toolSelect_Click);
      this._toolsMultiSelect.Name = "_toolsMultiSelect";
      this._toolsMultiSelect.Size = new Size(126, 22);
      this._toolsMultiSelect.Text = "MultiSelect";
      this._toolsMultiSelect.Click += new EventHandler(this._toolsMultiSelect_Click);
      this._toolsResize.Name = "_toolsResize";
      this._toolsResize.Size = new Size(126, 22);
      this._toolsResize.Text = "Resize";
      this._toolsResize.Click += new EventHandler(this._toolsResize_Click);
      this._toolsMove.Name = "_toolsMove";
      this._toolsMove.Size = new Size(126, 22);
      this._toolsMove.Text = "Move";
      this._toolsMove.Click += new EventHandler(this._toolsMove_Click);
      this._toolsRotate.Name = "_toolsRotate";
      this._toolsRotate.Size = new Size(126, 22);
      this._toolsRotate.Text = "Rotate";
      this._toolsRotate.Click += new EventHandler(this._toolsRotate_Click);
      this._toolsDeform.Name = "_toolsDeform";
      this._toolsDeform.Size = new Size(126, 22);
      this._toolsDeform.Text = "Deform";
      this._toolsDeform.Click += new EventHandler(this._toolsDeform_Click);
      this._toolsCopyPoint.Name = "_toolsCopyPoint";
      this._toolsCopyPoint.Size = new Size(126, 22);
      this._toolsCopyPoint.Text = "Copy Point";
      this._toolsCopyPoint.Visible = false;
      this._toolsCopyPoint.Click += new EventHandler(this._toolsCopyPoint_Click);
      this._menuLayout.DropDownItems.AddRange(new ToolStripItem[14]
      {
        (ToolStripItem) this._layoutGroup,
        (ToolStripItem) this._layoutUngroup,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this._layoutAlignLefts,
        (ToolStripItem) this._layoutAlignRights,
        (ToolStripItem) this._layoutAlignTops,
        (ToolStripItem) this._layoutAlignBottoms,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this._layoutMakeSameWidth,
        (ToolStripItem) this._layoutMakeSameHeight,
        (ToolStripItem) this._layoutMakeSameSize,
        (ToolStripItem) this.toolStripSeparator11,
        (ToolStripItem) this.bringToFrontToolStripMenuItem,
        (ToolStripItem) this.sendToBackToolStripMenuItem
      });
      this._menuLayout.Name = "_menuLayout";
      this._menuLayout.Size = new Size(52, 20);
      this._menuLayout.Text = "Layout";
      this._layoutGroup.Name = "_layoutGroup";
      this._layoutGroup.Size = new Size(162, 22);
      this._layoutGroup.Text = "Group";
      this._layoutGroup.Click += new EventHandler(this._contextGroup_Click);
      this._layoutUngroup.Name = "_layoutUngroup";
      this._layoutUngroup.Size = new Size(162, 22);
      this._layoutUngroup.Text = "Ungroup";
      this._layoutUngroup.Click += new EventHandler(this._contextUngroup_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(159, 6);
      this._layoutAlignLefts.Name = "_layoutAlignLefts";
      this._layoutAlignLefts.Size = new Size(162, 22);
      this._layoutAlignLefts.Text = "Align Lefts";
      this._layoutAlignLefts.Click += new EventHandler(this._contextAlignLefts_Click);
      this._layoutAlignRights.Name = "_layoutAlignRights";
      this._layoutAlignRights.Size = new Size(162, 22);
      this._layoutAlignRights.Text = "Align Rights";
      this._layoutAlignRights.Click += new EventHandler(this._contextAlignRights_Click);
      this._layoutAlignTops.Name = "_layoutAlignTops";
      this._layoutAlignTops.Size = new Size(162, 22);
      this._layoutAlignTops.Text = "Align Tops";
      this._layoutAlignTops.Click += new EventHandler(this._contextAlignTops_Click);
      this._layoutAlignBottoms.Name = "_layoutAlignBottoms";
      this._layoutAlignBottoms.Size = new Size(162, 22);
      this._layoutAlignBottoms.Text = "Align Bottoms";
      this._layoutAlignBottoms.Click += new EventHandler(this._contextAlignBottoms_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(159, 6);
      this._layoutMakeSameWidth.Name = "_layoutMakeSameWidth";
      this._layoutMakeSameWidth.Size = new Size(162, 22);
      this._layoutMakeSameWidth.Text = "Make Same Width";
      this._layoutMakeSameWidth.Click += new EventHandler(this._contextMakeSameWidth_Click);
      this._layoutMakeSameHeight.Name = "_layoutMakeSameHeight";
      this._layoutMakeSameHeight.Size = new Size(162, 22);
      this._layoutMakeSameHeight.Text = "Make Same Height";
      this._layoutMakeSameHeight.Click += new EventHandler(this._contextMakeSameHeight_Click);
      this._layoutMakeSameSize.Name = "_layoutMakeSameSize";
      this._layoutMakeSameSize.Size = new Size(162, 22);
      this._layoutMakeSameSize.Text = "Make Same Size";
      this._layoutMakeSameSize.Click += new EventHandler(this._contextMakeSameSize_Click);
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      this.toolStripSeparator11.Size = new Size(159, 6);
      this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
      this.bringToFrontToolStripMenuItem.Size = new Size(162, 22);
      this.bringToFrontToolStripMenuItem.Text = "Bring To Front";
      this.bringToFrontToolStripMenuItem.Click += new EventHandler(this.bringToFrontToolStripMenuItem_Click);
      this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
      this.sendToBackToolStripMenuItem.Size = new Size(162, 22);
      this.sendToBackToolStripMenuItem.Text = "Send To Back";
      this.sendToBackToolStripMenuItem.Click += new EventHandler(this.sendToBackToolStripMenuItem_Click);
      this._shapesBase.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this._baseRectangle,
        (ToolStripItem) this._baseEllipse
      });
      this._shapesBase.Name = "_shapesBase";
      this._shapesBase.Size = new Size(152, 22);
      this._shapesBase.Text = "Base";
      this._baseRectangle.Name = "_baseRectangle";
      this._baseRectangle.Size = new Size(122, 22);
      this._baseRectangle.Text = "Rectangle";
      this._baseRectangle.Click += new EventHandler(this._baseRectangle_Click);
      this._baseEllipse.Name = "_baseEllipse";
      this._baseEllipse.Size = new Size(122, 22);
      this._baseEllipse.Text = "Ellipse";
      this._baseEllipse.Click += new EventHandler(this._baseEllipse_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(159, 6);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(159, 6);
      this._mainSplitContainer.Dock = DockStyle.Fill;
      this._mainSplitContainer.Location = new Point(0, 0);
      this._mainSplitContainer.Name = "_mainSplitContainer";
      this._mainSplitContainer.Panel1.Controls.Add((Control) this._scrollingPanel);
      this._mainSplitContainer.Panel1.Resize += new EventHandler(this._mainSplitContainer_Panel1_Resize);
      this._mainSplitContainer.Panel2.Controls.Add((Control) this._tab);
      this._mainSplitContainer.Size = new Size(611, 447);
      this._mainSplitContainer.SplitterDistance = 405;
      this._mainSplitContainer.TabIndex = 1;
      this._scrollingPanel.AutoScroll = true;
      this._scrollingPanel.Controls.Add((Control) this._drawingPanel);
      this._scrollingPanel.Dock = DockStyle.Fill;
      this._scrollingPanel.Location = new Point(0, 0);
      this._scrollingPanel.Name = "_scrollingPanel";
      this._scrollingPanel.Size = new Size(405, 447);
      this._scrollingPanel.TabIndex = 2;
      this._drawingPanel.ActiveCursor = Cursors.Default;
      select.MouseDownPoint = new Point(0, 0);
      select.MouseUpPoint = new Point(0, 0);
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) select;
      this._drawingPanel.AutoScroll = true;
      this._drawingPanel.BackColor = Color.White;
      this._drawingPanel.Cursor = Cursors.Default;
      this._drawingPanel.EnableWheelZoom = true;
      this._drawingPanel.Location = new Point(0, 0);
      this._drawingPanel.Name = "_drawingPanel";
      this._drawingPanel.Size = new Size(402, 447);
      this._drawingPanel.TabIndex = 0;
      this._drawingPanel.Zoom = 1f;
      this._drawingPanel.MouseDown += new MouseEventHandler(this._drawingPanel_MouseDown);
      this._tab.Controls.Add((Control) this._tabPageProperties);
      this._tab.Controls.Add((Control) this._tabPagePanelProperties);
      this._tab.Controls.Add((Control) this._tabPageEvents);
      this._tab.Dock = DockStyle.Fill;
      this._tab.Location = new Point(0, 0);
      this._tab.Name = "_tab";
      this._tab.SelectedIndex = 0;
      this._tab.Size = new Size(202, 447);
      this._tab.TabIndex = 0;
      this._tabPageProperties.Controls.Add((Control) this._propertyGrid);
      this._tabPageProperties.Location = new Point(4, 22);
      this._tabPageProperties.Name = "_tabPageProperties";
      this._tabPageProperties.Padding = new Padding(3);
      this._tabPageProperties.Size = new Size(194, 421);
      this._tabPageProperties.TabIndex = 0;
      this._tabPageProperties.Text = "Shape Properties";
      this._tabPageProperties.UseVisualStyleBackColor = true;
      this._propertyGrid.Dock = DockStyle.Fill;
      this._propertyGrid.Location = new Point(3, 3);
      this._propertyGrid.Name = "_propertyGrid";
      this._propertyGrid.Size = new Size(188, 415);
      this._propertyGrid.TabIndex = 1;
      this._tabPagePanelProperties.Controls.Add((Control) this._propertyGridPanel);
      this._tabPagePanelProperties.Location = new Point(4, 22);
      this._tabPagePanelProperties.Name = "_tabPagePanelProperties";
      this._tabPagePanelProperties.Size = new Size(194, 421);
      this._tabPagePanelProperties.TabIndex = 2;
      this._tabPagePanelProperties.Text = "Panel Properties";
      this._tabPagePanelProperties.UseVisualStyleBackColor = true;
      this._propertyGridPanel.Dock = DockStyle.Fill;
      this._propertyGridPanel.Location = new Point(0, 0);
      this._propertyGridPanel.Name = "_propertyGridPanel";
      this._propertyGridPanel.Size = new Size(194, 421);
      this._propertyGridPanel.TabIndex = 0;
      this._tabPageEvents.Controls.Add((Control) this._btnReset);
      this._tabPageEvents.Controls.Add((Control) this._listEvents);
      this._tabPageEvents.Location = new Point(4, 22);
      this._tabPageEvents.Name = "_tabPageEvents";
      this._tabPageEvents.Size = new Size(194, 421);
      this._tabPageEvents.TabIndex = 1;
      this._tabPageEvents.Text = "Events";
      this._tabPageEvents.UseVisualStyleBackColor = true;
      this._btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this._btnReset.Location = new Point(116, 395);
      this._btnReset.Name = "_btnReset";
      this._btnReset.Size = new Size(75, 23);
      this._btnReset.TabIndex = 1;
      this._btnReset.Text = "Reset";
      this._btnReset.UseVisualStyleBackColor = true;
      this._btnReset.Click += new EventHandler(this._btnReset_Click);
      this._listEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this._listEvents.FormattingEnabled = true;
      this._listEvents.Location = new Point(3, 0);
      this._listEvents.Name = "_listEvents";
      this._listEvents.Size = new Size(191, 394);
      this._listEvents.TabIndex = 0;
      this._toolBar.Location = new Point(0, 24);
      this._toolBar.Name = "_toolBar";
      this._toolBar.Size = new Size(611, 25);
      this._toolBar.TabIndex = 2;
      this._toolBar.Text = "toolStrip1";
      this._statusBar.Location = new Point(0, 499);
      this._statusBar.Name = "_statusBar";
      this._statusBar.Size = new Size(611, 22);
      this._statusBar.TabIndex = 3;
      this._statusBar.Text = "statusStrip1";
      this._panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this._panel.Controls.Add((Control) this._mainSplitContainer);
      this._panel.Location = new Point(0, 49);
      this._panel.Name = "_panel";
      this._panel.Size = new Size(611, 447);
      this._panel.TabIndex = 4;
      this._contextMenu.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this._contextLayout
      });
      this._contextMenu.Name = "_contextMenu";
      this._contextMenu.Size = new Size(108, 26);
      this._contextLayout.DropDownItems.AddRange(new ToolStripItem[14]
      {
        (ToolStripItem) this._contextGroup,
        (ToolStripItem) this._contextUngroup,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this._contextAlignLefts,
        (ToolStripItem) this._contextAlignRights,
        (ToolStripItem) this._contextAlignTops,
        (ToolStripItem) this._contextAlignBottoms,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this._contextMakeSameWidth,
        (ToolStripItem) this._contextMakeSameHeight,
        (ToolStripItem) this._contextMakeSameSize,
        (ToolStripItem) this.toolStripSeparator12,
        (ToolStripItem) this.bringToFrontToolStripMenuItem1,
        (ToolStripItem) this.sendToBackToolStripMenuItem1
      });
      this._contextLayout.Name = "_contextLayout";
      this._contextLayout.Size = new Size(107, 22);
      this._contextLayout.Text = "Layout";
      this._contextGroup.Name = "_contextGroup";
      this._contextGroup.Size = new Size(162, 22);
      this._contextGroup.Text = "Group";
      this._contextGroup.Click += new EventHandler(this._contextGroup_Click);
      this._contextUngroup.Name = "_contextUngroup";
      this._contextUngroup.Size = new Size(162, 22);
      this._contextUngroup.Text = "Ungroup";
      this._contextUngroup.Click += new EventHandler(this._contextUngroup_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(159, 6);
      this._contextAlignLefts.Name = "_contextAlignLefts";
      this._contextAlignLefts.Size = new Size(162, 22);
      this._contextAlignLefts.Text = "Align Lefts";
      this._contextAlignLefts.Click += new EventHandler(this._contextAlignLefts_Click);
      this._contextAlignRights.Name = "_contextAlignRights";
      this._contextAlignRights.Size = new Size(162, 22);
      this._contextAlignRights.Text = "Align Rights";
      this._contextAlignRights.Click += new EventHandler(this._contextAlignRights_Click);
      this._contextAlignTops.Name = "_contextAlignTops";
      this._contextAlignTops.Size = new Size(162, 22);
      this._contextAlignTops.Text = "Align Tops";
      this._contextAlignTops.Click += new EventHandler(this._contextAlignTops_Click);
      this._contextAlignBottoms.Name = "_contextAlignBottoms";
      this._contextAlignBottoms.Size = new Size(162, 22);
      this._contextAlignBottoms.Text = "Align Bottoms";
      this._contextAlignBottoms.Click += new EventHandler(this._contextAlignBottoms_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(159, 6);
      this._contextMakeSameWidth.Name = "_contextMakeSameWidth";
      this._contextMakeSameWidth.Size = new Size(162, 22);
      this._contextMakeSameWidth.Text = "Make Same Width";
      this._contextMakeSameWidth.Click += new EventHandler(this._contextMakeSameWidth_Click);
      this._contextMakeSameHeight.Name = "_contextMakeSameHeight";
      this._contextMakeSameHeight.Size = new Size(162, 22);
      this._contextMakeSameHeight.Text = "Make Same Height";
      this._contextMakeSameHeight.Click += new EventHandler(this._contextMakeSameHeight_Click);
      this._contextMakeSameSize.Name = "_contextMakeSameSize";
      this._contextMakeSameSize.Size = new Size(162, 22);
      this._contextMakeSameSize.Text = "Make Same Size";
      this._contextMakeSameSize.Click += new EventHandler(this._contextMakeSameSize_Click);
      this._openDialog.Filter = "xml files (.xml)|*.xml";
      this._saveDialog.Filter = "xml files (.xml)|*.xml";
      this.toolStripSeparator12.Name = "toolStripSeparator12";
      this.toolStripSeparator12.Size = new Size(159, 6);
      this.bringToFrontToolStripMenuItem1.Name = "bringToFrontToolStripMenuItem1";
      this.bringToFrontToolStripMenuItem1.Size = new Size(162, 22);
      this.bringToFrontToolStripMenuItem1.Text = "Bring To Front";
      this.bringToFrontToolStripMenuItem1.Click += new EventHandler(this.bringToFrontToolStripMenuItem_Click);
      this.sendToBackToolStripMenuItem1.Name = "sendToBackToolStripMenuItem1";
      this.sendToBackToolStripMenuItem1.Size = new Size(162, 22);
      this.sendToBackToolStripMenuItem1.Text = "Send To Back";
      this.sendToBackToolStripMenuItem1.Click += new EventHandler(this.sendToBackToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(611, 521);
      this.Controls.Add((Control) this._statusBar);
      this.Controls.Add((Control) this._toolBar);
      this.Controls.Add((Control) this._menu);
      this.Controls.Add((Control) this._panel);
      this.MainMenuStrip = this._menu;
      this.Name = nameof (MainForm);
      this.Text = "Painter";
      this._menu.ResumeLayout(false);
      this._menu.PerformLayout();
      this._mainSplitContainer.Panel1.ResumeLayout(false);
      this._mainSplitContainer.Panel2.ResumeLayout(false);
      this._mainSplitContainer.ResumeLayout(false);
      this._scrollingPanel.ResumeLayout(false);
      this._tab.ResumeLayout(false);
      this._tabPageProperties.ResumeLayout(false);
      this._tabPagePanelProperties.ResumeLayout(false);
      this._tabPageEvents.ResumeLayout(false);
      this._panel.ResumeLayout(false);
      this._contextMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public MainForm()
    {
      this.InitializeComponent();
      this._drawingPanel.Shapes.ShapeChanged += new ShapeChangingHandler(this.Shapes_ShapeChanged);
      this._drawingPanel.Shapes.ShapeMovementOccurred += new MovementHandler(this._shapes_ShapeMovementOccurred);
      this._drawingPanel.Shapes.ShapeAppearanceChanged += new AppearanceHandler(this.Shapes_ShapeAppearanceChanged);
      this._propertyGridPanel.SelectedObject = (object) this._drawingPanel;
    }

    private void MainForm_SelectedShapes(Globe.Graphics.Bidimensional.Common.Tool tool, ShapeCollection shapes) => this._propertyGrid.SelectedObjects = ShapeCollection.ToObjects(shapes);

    private void _btnReset_Click(object sender, EventArgs e) => this._listEvents.Items.Clear();

    private void Shapes_ShapeChanged(IShape shape, object changing) => this._listEvents.Items.Add((object) (shape.ToString() + ", " + changing.ToString()));

    private void _shapes_ShapeMovementOccurred(Transformer transformer) => this._listEvents.Items.Add((object) (transformer.Shape.ToString() + " Generic movement occurred"));

    private void Shapes_ShapeAppearanceChanged(Globe.Graphics.Bidimensional.Common.Appearance appearance) => this._listEvents.Items.Add((object) (appearance.Shape.ToString() + " Generic Appearance changing occurred"));

    private void _editUndo_Click(object sender, EventArgs e) => this._drawingPanel.Undo();

    private void _editRedo_Click(object sender, EventArgs e) => this._drawingPanel.Redo();

    private void _editCut_Click(object sender, EventArgs e) => this._drawingPanel.Cut();

    private void _editCopy_Click(object sender, EventArgs e) => this._drawingPanel.Copy();

    private void _editPaste_Click(object sender, EventArgs e) => this._drawingPanel.Paste();

    private void _editDelete_Click(object sender, EventArgs e) => this._drawingPanel.Delete();

    private void _editSelectAll_Click(object sender, EventArgs e)
    {
      Globe.Graphics.Bidimensional.Common.Select.SelectAll(this._drawingPanel.Shapes);
      this._drawingPanel.Invalidate();
    }

    private void _menuOpen_Click(object sender, EventArgs e)
    {
      if (this._openDialog.ShowDialog() != DialogResult.OK)
        return;
      Serializer serializer = new Serializer();
      try
      {
        this._drawingPanel.Shapes = serializer.Deserialize(this._openDialog.FileName) as ShapeCollection;
        this._drawingPanel.Invalidate();
      }
      catch (XmlSerializationException ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void _menuSave_Click(object sender, EventArgs e)
    {
      if (this._saveDialog.ShowDialog() != DialogResult.OK)
        return;
      Serializer serializer = new Serializer();
      try
      {
        serializer.Serialize(this._saveDialog.FileName, (object) this._drawingPanel.Shapes);
      }
      catch (XmlSerializationException ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void _zoomZoomIn_Click(object sender, EventArgs e) => this._drawingPanel.Zoom = 1.1f;

    private void _zoomZoomOut_Click(object sender, EventArgs e) => this._drawingPanel.Zoom = 0.9f;

    private void _toolsPointer_Click(object sender, EventArgs e)
    {
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new Pointer();
      (this._drawingPanel.ActiveTool as Globe.Graphics.Bidimensional.Common.Select).SelectedShapes += new Globe.Graphics.Bidimensional.Common.Select.OnSelectedShapes(this.MainForm_SelectedShapes);
    }

    private void _toolSelect_Click(object sender, EventArgs e)
    {
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new Globe.Graphics.Bidimensional.Common.Select();
      (this._drawingPanel.ActiveTool as Globe.Graphics.Bidimensional.Common.Select).SelectedShapes += new Globe.Graphics.Bidimensional.Common.Select.OnSelectedShapes(this.MainForm_SelectedShapes);
    }

    private void _toolsMove_Click(object sender, EventArgs e)
    {
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new Globe.Graphics.Bidimensional.Base.Move();
      (this._drawingPanel.ActiveTool as Globe.Graphics.Bidimensional.Common.Select).SelectedShapes += new Globe.Graphics.Bidimensional.Common.Select.OnSelectedShapes(this.MainForm_SelectedShapes);
    }

    private void _toolsRotate_Click(object sender, EventArgs e)
    {
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new Rotate();
      (this._drawingPanel.ActiveTool as Globe.Graphics.Bidimensional.Common.Select).SelectedShapes += new Globe.Graphics.Bidimensional.Common.Select.OnSelectedShapes(this.MainForm_SelectedShapes);
    }

    private void _toolsMultiSelect_Click(object sender, EventArgs e)
    {
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new MultiSelect();
      (this._drawingPanel.ActiveTool as MultiSelect).SelectedShapes += new MultiSelect.OnSelectedShapes(this.MainForm_SelectedShapes);
    }

    private void _toolsResize_Click(object sender, EventArgs e)
    {
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new Globe.Graphics.Bidimensional.Base.Resize();
      (this._drawingPanel.ActiveTool as Globe.Graphics.Bidimensional.Common.Select).SelectedShapes += new Globe.Graphics.Bidimensional.Common.Select.OnSelectedShapes(this.MainForm_SelectedShapes);
    }

    private void _toolsDeform_Click(object sender, EventArgs e)
    {
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new Deform();
      (this._drawingPanel.ActiveTool as Globe.Graphics.Bidimensional.Common.Select).SelectedShapes += new Globe.Graphics.Bidimensional.Common.Select.OnSelectedShapes(this.MainForm_SelectedShapes);
    }

    private void _toolsCopyPoint_Click(object sender, EventArgs e)
    {
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new CopyPoint();
      (this._drawingPanel.ActiveTool as Globe.Graphics.Bidimensional.Common.Select).SelectedShapes += new Globe.Graphics.Bidimensional.Common.Select.OnSelectedShapes(this.MainForm_SelectedShapes);
    }

    private void _drawingRectangle_Click(object sender, EventArgs e) => this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new DrawShape((IShape) new Globe.Graphics.Bidimensional.Base.Rectangle());

    private void _drawingLine_Click(object sender, EventArgs e) => this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new DrawShape((IShape) new Line());

    private void _drawingEllipse_Click(object sender, EventArgs e) => this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new DrawShape((IShape) new Ellipse());

    private void _drawingPolygon_Click(object sender, EventArgs e)
    {
      GraphicsPath geometric = new GraphicsPath();
      geometric.AddPolygon(new Point[4]
      {
        new Point(0, 0),
        new Point(0, 40),
        new Point(20, 45),
        new Point(15, 20)
      });
      CustomShape customShape = new CustomShape(geometric);
      customShape.Selected = true;
      customShape.Locked = false;
      customShape.Dimension = (SizeF) new Size(1, 1);
      this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new DrawShape((IShape) customShape);
    }

    private void _drawingSloppedLine_Click(object sender, EventArgs e) => this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new DrawSloppedLine();

    private void _drawingFreeLine_Click(object sender, EventArgs e) => this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new DrawFreeLine();

    private void _drawingText_Click(object sender, EventArgs e) => this._drawingPanel.ActiveTool = (Globe.Graphics.Bidimensional.Common.Tool) new DrawShape((IShape) new Globe.Graphics.Bidimensional.Base.Text());

    private void _toolsHorizontalLeft_Click(object sender, EventArgs e)
    {
      ShapeCollection selectedShapes = Globe.Graphics.Bidimensional.Common.Select.GetSelectedShapes(this._drawingPanel.Shapes);
      if (selectedShapes.Count == 0)
        return;
      foreach (IShape shape in (Collection<IShape>) selectedShapes)
        shape.Transformer.MirrorHorizontal(shape.Location.X);
      this._drawingPanel.Invalidate();
    }

    private void _toolsHorizontalRight_Click(object sender, EventArgs e)
    {
      ShapeCollection selectedShapes = Globe.Graphics.Bidimensional.Common.Select.GetSelectedShapes(this._drawingPanel.Shapes);
      if (selectedShapes.Count == 0)
        return;
      foreach (IShape shape in (Collection<IShape>) selectedShapes)
        shape.Transformer.MirrorHorizontal(shape.Location.X + shape.Dimension.Width);
      this._drawingPanel.Invalidate();
    }

    private void _toolsVerticalTop_Click(object sender, EventArgs e)
    {
      ShapeCollection selectedShapes = Globe.Graphics.Bidimensional.Common.Select.GetSelectedShapes(this._drawingPanel.Shapes);
      if (selectedShapes.Count == 0)
        return;
      foreach (IShape shape in (Collection<IShape>) selectedShapes)
        shape.Transformer.MirrorVertical(shape.Location.Y);
      this._drawingPanel.Invalidate();
    }

    private void _toolsVerticalBottom_Click(object sender, EventArgs e)
    {
      ShapeCollection selectedShapes = Globe.Graphics.Bidimensional.Common.Select.GetSelectedShapes(this._drawingPanel.Shapes);
      if (selectedShapes.Count == 0)
        return;
      foreach (IShape shape in (Collection<IShape>) selectedShapes)
        shape.Transformer.MirrorVertical(shape.Location.Y + shape.Dimension.Height);
      this._drawingPanel.Invalidate();
    }

    private void _baseRectangle_Click(object sender, EventArgs e)
    {
      this._drawingPanel.Shapes.Add((IShape) new Globe.Graphics.Bidimensional.Base.Rectangle());
      this._drawingPanel.Invalidate();
    }

    private void _baseEllipse_Click(object sender, EventArgs e)
    {
      this._drawingPanel.Shapes.Add((IShape) new Ellipse());
      this._drawingPanel.Invalidate();
    }

    private void _drawingPanel_MouseDown(object sender, MouseEventArgs e)
    {
      if (Globe.Graphics.Bidimensional.Common.Select.GetSelectedShapes(this._drawingPanel.Shapes).Count == 0)
        this._drawingPanel.ContextMenuStrip = (ContextMenuStrip) null;
      else
        this._drawingPanel.ContextMenuStrip = this._contextMenu;
    }

    private void _mainSplitContainer_Panel1_Resize(object sender, EventArgs e)
    {
      if (this._drawingPanel.Size.Width < this._mainSplitContainer.Panel1.Width)
        this._drawingPanel.Size = new Size(this._mainSplitContainer.Panel1.Width, this._drawingPanel.Size.Height);
      if (this._drawingPanel.Size.Height >= this._mainSplitContainer.Panel1.Height)
        return;
      this._drawingPanel.Size = new Size(this._drawingPanel.Size.Width, this._mainSplitContainer.Panel1.Height);
    }

    private void _contextGroup_Click(object sender, EventArgs e)
    {
      GroupEngine.Group((IDocument) this._drawingPanel);
      this._drawingPanel.Invalidate();
    }

    private void _contextUngroup_Click(object sender, EventArgs e)
    {
      GroupEngine.Ungroup((IDocument) this._drawingPanel);
      this._drawingPanel.Invalidate();
    }

    private void _contextAlignLefts_Click(object sender, EventArgs e)
    {
      GroupEngine.AlignLefts((IDocument) this._drawingPanel);
      this._drawingPanel.Invalidate();
    }

    private void _contextAlignRights_Click(object sender, EventArgs e)
    {
      GroupEngine.AlignRights((IDocument) this._drawingPanel);
      this._drawingPanel.Invalidate();
    }

    private void _contextAlignTops_Click(object sender, EventArgs e)
    {
      GroupEngine.AlignTops((IDocument) this._drawingPanel);
      this._drawingPanel.Invalidate();
    }

    private void _contextAlignBottoms_Click(object sender, EventArgs e)
    {
      GroupEngine.AlignBottoms((IDocument) this._drawingPanel);
      this._drawingPanel.Invalidate();
    }

    private void _contextMakeSameWidth_Click(object sender, EventArgs e)
    {
      GroupEngine.MakeSameWidth((IDocument) this._drawingPanel);
      this._drawingPanel.Invalidate();
    }

    private void _contextMakeSameHeight_Click(object sender, EventArgs e)
    {
      GroupEngine.MakeSameHeight((IDocument) this._drawingPanel);
      this._drawingPanel.Invalidate();
    }

    private void _contextMakeSameSize_Click(object sender, EventArgs e)
    {
      GroupEngine.MakeSameSize((IDocument) this._drawingPanel);
      this._drawingPanel.Invalidate();
    }

    private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (Globe.Graphics.Bidimensional.Common.Select.LastSelectedShape == null)
        return;
      this._drawingPanel.Shapes.BringToFront(Globe.Graphics.Bidimensional.Common.Select.LastSelectedShape);
    }

    private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (Globe.Graphics.Bidimensional.Common.Select.LastSelectedShape == null)
        return;
      this._drawingPanel.Shapes.SendToBack(Globe.Graphics.Bidimensional.Common.Select.LastSelectedShape);
    }
  }
}
