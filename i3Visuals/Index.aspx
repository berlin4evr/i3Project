<%@ Page Language="C#" EnableSessionState="True" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="i3Visuals.Index" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>i3 | JSON Data</title>
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="plugins/fontawesome-free/css/all.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Tempusdominus Bootstrap 4 -->
    <link rel="stylesheet" href="plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- JQVMap -->
    <link rel="stylesheet" href="plugins/jqvmap/jqvmap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/adminlte.min.css" />
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="plugins/overlayScrollbars/css/OverlayScrollbars.min.css" />
    <!-- Daterange picker -->
    <link rel="stylesheet" href="plugins/daterangepicker/daterangepicker.css" />
    <!-- summernote -->
    <link rel="stylesheet" href="plugins/summernote/summernote-bs4.min.css" />

    <!-- ---------------------------Bottom Links---------------------------------------------------------------------- -->
    <!-- jQuery -->
    <script src="plugins/jquery/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="plugins/jquery-ui/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <%--    <script type="text/javascript">
  $.widget.bridge('uibutton', $.ui.button)
    </script>--%>
    <!-- Bootstrap 4 -->
    <script src="plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- ChartJS -->
    <script src="plugins/chart.js/Chart.min.js"></script>
    <!-- Sparkline -->
    <script src="plugins/sparklines/sparkline.js"></script>
    <!-- JQVMap -->
    <script src="plugins/jqvmap/jquery.vmap.min.js"></script>
    <script src="plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
    <!-- jQuery Knob Chart -->
    <script src="plugins/jquery-knob/jquery.knob.min.js"></script>
    <!-- daterangepicker -->
    <script src="plugins/moment/moment.min.js"></script>
    <script src="plugins/daterangepicker/daterangepicker.js"></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src="plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
    <!-- Summernote -->
    <script src="plugins/summernote/summernote-bs4.min.js"></script>
    <!-- overlayScrollbars -->
    <script src="plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
    <!-- AdminLTE App -->
    <script src="dist/js/adminlte.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="dist/js/demo.js"></script>
    <!-- AdminLTE dashboard demo -->
    <script src="dist/js/pages/dashboard.js"></script>

    <!-- ---------------------------Bottom Links---------------------------------------------------------------------- -->
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">

            <!-- Preloader -->
            <div class="preloader flex-column justify-content-center align-items-center">
                <img class="animation__shake" src="dist/img/i3Logo.png" alt="i3 Logo" height="60" width="60" />
            </div>

            <!-- Navbar -->
            <nav class="main-header navbar navbar-expand navbar-white navbar-light">
                <!-- Left navbar links -->
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" data-widget="pushmenu" href="#" role="button"><i class="fas fa-bars"></i></a>
                    </li>
                    <li class="nav-item d-none d-sm-inline-block">
                        <a href="index.html" class="nav-link">Home</a>
                    </li>
                </ul>

                <!-- Right navbar links -->
                <ul class="navbar-nav ml-auto">

                    <!-- Messages Dropdown Menu -->
                    <li class="nav-item dropdown">
                        <div class="dropdown-menu dropdown-menu-lg dropdown-menu-right">
                            <a href="#" class="dropdown-item"></a>
                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item">
                                <!-- Message Start -->
                                <div class="media">
                                    <img src="dist/img/user8-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3" />
                                    <div class="media-body">
                                        <h3 class="dropdown-item-title">John Pierce
                  <span class="float-right text-sm text-muted"><i class="fas fa-star"></i></span>
                                        </h3>
                                        <p class="text-sm">I got your message bro</p>
                                        <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>4 Hours Ago</p>
                                    </div>
                                </div>
                                <!-- Message End -->
                            </a>
                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item">
                                <!-- Message Start -->
                                <div class="media">
                                    <img src="dist/img/user3-128x128.jpg" alt="User Avatar" class="img-size-50 img-circle mr-3" />
                                    <div class="media-body">
                                        <h3 class="dropdown-item-title">Nora Silvester
                  <span class="float-right text-sm text-warning"><i class="fas fa-star"></i></span>
                                        </h3>
                                        <p class="text-sm">The subject goes here</p>
                                        <p class="text-sm text-muted"><i class="far fa-clock mr-1"></i>4 Hours Ago</p>
                                    </div>
                                </div>
                                <!-- Message End -->
                            </a>
                            <div class="dropdown-divider"></div>
                            <a href="#" class="dropdown-item dropdown-footer">See All Messages</a>
                        </div>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-widget="fullscreen" href="#" role="button">
                            <i class="fas fa-expand-arrows-alt"></i>
                        </a>
                    </li>
                </ul>
            </nav>
            <!-- /.navbar -->

            <!-- Main Sidebar Container -->
            <aside class="main-sidebar sidebar-dark-primary elevation-4">
                <!-- Brand Logo -->
                <a href="index.html" class="brand-link">
                    <img src="dist/img/AdminLTELogo.png" alt="AdminLTE Logo" class="brand-image img-circle elevation-3" style="opacity: .8" />
                    <span class="brand-text font-weight-light">i3 Project</span>
                </a>

                <!-- Sidebar -->
                <div class="sidebar">
                    <!-- Sidebar user panel (optional) -->
                    <!-- <div class="user-panel mt-3 pb-3 mb-3 d-flex">
        <div class="image">
          <img src="dist/img/user2-160x160.jpg" class="img-circle elevation-2" alt="User Image">
        </div>
        <div class="info">
          <a href="#" class="d-block">Alexander Pierce</a>
        </div>
      </div> -->

                    <!-- Sidebar Menu -->
                    <nav class="mt-2">
                        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
                            <!-- Add icons to the links using the .nav-icon class
               with font-awesome or any other icon font library -->
                            <li class="nav-item menu-open">
                                <a href="#" class="nav-link ">
                                    <i class="nav-icon fas fa-bars"></i>
                                    <p>
                                        Menu
                <i class="right fas fa-angle-left"></i>
                                    </p>
                                </a>
                                <ul class="nav nav-treeview">
                                    <li class="nav-item">
                                        <a href="./index.html" class="nav-link ">
                                            <i class="far fa-circle nav-icon"></i>
                                            <p>Dashboard</p>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </nav>
                    <!-- /.sidebar-menu -->
                </div>
                <!-- /.sidebar -->
            </aside>

            <!-- Content Wrapper. Contains page content -->
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <div class="content-header">
                    <div class="container-fluid">
                        <div class="row mb-2">
                            <div class="col-sm-6">
                                <h1 class="m-0">Dashboard</h1>
                            </div>
                            <!-- /.col -->
                            <div class="col-sm-6">
                                <ol class="breadcrumb float-sm-right">
                                    <li class="breadcrumb-item"><a href="#">Home</a></li>
                                    <li class="breadcrumb-item active">Dashboard</li>
                                </ol>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.container-fluid -->
                </div>
                <!-- /.content-header -->

                <!-- Main content -->
                <section class="content">
                    <div class="container-fluid">
                        <!-- Small boxes (Stat box) -->
                        <div class="row">
                            <div class="col-lg-3 col-6">
                                <!-- small box -->
                                <div class="small-box bg-info">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblTotalHits" runat="server" Text="7"></asp:Label>
                                        </h3>

                                        <p>Total Hits</p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-stats-bars"></i>
                                    </div>
                                </div>
                            </div>
                            <!-- ./col -->
                            <div class="col-lg-3 col-6">
                                <!-- small box -->
                                <div class="small-box bg-success">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblSearchEngineTime" runat="server" Text="17"></asp:Label></h3>

                                        <p>Search Engine Time</p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-stats-bars"></i>
                                    </div>
                                </div>
                            </div>
                            <!-- ./col -->
                            <div class="col-lg-3 col-6">
                                <!-- small box -->
                                <div class="small-box badge-secondary">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblSearchEngineRoundTrip" runat="server" Text="3"></asp:Label></h3>

                                        <p>Search Engine Round Trip</p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-stats-bars"></i>
                                    </div>
                                </div>
                            </div>
                            <!-- ./col -->
                            <div class="col-lg-3 col-6">
                                <!-- small box -->
                                <div class="small-box bg-danger">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblSearchEngineProcessingTime" runat="server" Text="5ms"></asp:Label></h3>

                                        <p>Search Engine Processing Time</p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-stats-bars"></i>
                                    </div>
                                </div>
                            </div>
                            <!-- ./col -->
                        </div>
                        <!-- /.row -->
                        <!-- Main row -->
                        <div class="row">
                            <!-- Left col -->
                            <section class="col-lg-7 connectedSortable">
                                <!-- Custom tabs (Charts with tabs)-->
                                <div class="card">
                                    <div class="card-header">
                                        <h3 class="card-title">
                                            <i class="fas fa-chart-pie mr-1"></i>
                                            Sales
                                        </h3>
                                        <div class="card-tools">
                                            <ul class="nav nav-pills ml-auto">
                                                <li class="nav-item">
                                                    <a class="nav-link active" href="#revenue-chart" data-toggle="tab">Area</a>
                                                </li>
                                                <li class="nav-item">
                                                    <a class="nav-link" href="#sales-chart" data-toggle="tab">Donut</a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- /.card-header -->
                                    <div class="card-body">
                                        <div class="tab-content p-0">
                                            <!-- Morris chart - Sales -->
                                            <div class="chart tab-pane active" id="revenue-chart"
                                                style="position: relative; height: 300px;">
                                                <canvas id="revenue-chart-canvas" height="300" style="height: 300px;"></canvas>
                                            </div>
                                            <div class="chart tab-pane" id="sales-chart" style="position: relative; height: 300px;">
                                                <canvas id="sales-chart-canvas" height="300" style="height: 300px;"></canvas>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.card-body -->
                                </div>
                                <!-- /.card -->
                                <asp:Button ID="Button1" runat="server" Text="Click Here" OnClick="Button1_Click" />
                                <asp:Chart ID="chartData" runat="server">
                                    <Titles>
                                        <asp:Title Text="Increase or decrease of refinance loan geography-wise"></asp:Title>
                                    </Titles>
                                    <Series>
                                        <asp:Series Name="Series1" XValueMember="Year" YValueMembers="Value" ChartArea="ChartArea1" ChartType="Bar"></asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1">
                                            <AxisX Title="Year"></AxisX>
                                            <AxisY Title="Values"></AxisY>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                            </section>
                            <!-- /.Left col -->
                            <!-- right col (We are only adding the ID to make the widgets sortable)-->
                            <section class="col-lg-5 connectedSortable">

                                <!-- Map card -->
                                <div class="card bg-gradient-primary" style="display: none;">
                                    <div class="card-header border-0">
                                        <h3 class="card-title">
                                            <i class="fas fa-map-marker-alt mr-1"></i>
                                            Visitors
                                        </h3>
                                        <!-- card tools -->
                                        <div class="card-tools">
                                            <button type="button" class="btn btn-primary btn-sm daterange" title="Date range">
                                                <i class="far fa-calendar-alt"></i>
                                            </button>
                                            <button type="button" class="btn btn-primary btn-sm" data-card-widget="collapse" title="Collapse">
                                                <i class="fas fa-minus"></i>
                                            </button>
                                        </div>
                                        <!-- /.card-tools -->
                                    </div>
                                    <div class="card-body">
                                        <div id="world-map" style="height: 250px; width: 100%;"></div>
                                    </div>
                                    <!-- /.card-body-->
                                    <div class="card-footer bg-transparent">
                                        <div class="row">
                                            <div class="col-4 text-center">
                                                <div id="sparkline-1"></div>
                                            </div>
                                            <!-- ./col -->
                                            <div class="col-4 text-center">
                                                <div id="sparkline-2"></div>

                                            </div>
                                            <!-- ./col -->
                                            <div class="col-4 text-center">
                                                <div id="sparkline-3"></div>

                                            </div>
                                            <!-- ./col -->
                                        </div>
                                        <!-- /.row -->
                                    </div>
                                </div>
                                <!-- /.card -->
                            </section>
                            <!-- right col -->
                        </div>
                        <!-- /.row (main row) -->
                    </div>
                    <!-- /.container-fluid -->
                </section>
                <!-- /.content -->
            </div>
            <!-- /.content-wrapper -->
            <footer class="main-footer">
                <strong>Copyright &copy; 2022 </strong>
                All rights reserved.
    <div class="float-right d-none d-sm-inline-block">
        <b>TietoEvry</b> V3.2.0
    </div>
            </footer>

            <!-- Control Sidebar -->
            <aside class="control-sidebar control-sidebar-dark">
                <!-- Control sidebar content goes here -->
            </aside>
            <!-- /.control-sidebar -->

        </div>
    </form>
</body>
</html>
