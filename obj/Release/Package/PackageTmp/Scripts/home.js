$(function () {

    //1.初始化Table
    var oTable = new TableInit();
    oTable.Init();

    //2.初始化Button的点击事件
    var oButtonInit = new ButtonInit();
    oButtonInit.Init();
    
    $("#btn_query").bind("click", function () {
        $("#tb_departments").bootstrapTable('destroy');
        console.log(oTable.Init());
        oTable.Init();
    });

});


var TableInit = function () {
    var oTableInit = new Object();
    //初始化Table
    oTableInit.Init = function () {
        $('#tb_departments').bootstrapTable({
            url: '/Visitor/getAllVisitor',         //请求后台的URL（*）
            method: 'get',                      //请求方式（*）
            queryParams: oTableInit.queryParams,//传递参数（*）
            dataType: "json",//数据类型
            success: function (msg) {
                alert("获取数据");
                console.log(msg);
                $('#tb_departments').bootstrapTable('load', msg);
            },
            //  data:[
			//  {
			//      "github": {
			//          "name": "bootstrap-table",
			//          "count": {
			//              "stargazers": 768,
			//              "forks": 183
			//          },
			//          "description": "An extended Bootstrap table with radio, checkbox, sort, pagination, and other added features. (supports twitter bootstrap v2 and v3)"
			//      }
			//  }
			//],
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: true,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            //contentType: "application/x-www-form-urlencoded",
            //queryParamsType: "",
            pagination: true,                   //是否显示分页（*）
            queryParamsType:"",
            sortable: true,                     //是否启用排序
            sortOrder: "asc",                   //排序方式          
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber:1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            pageList: [10, 20, 30, 100],        //可供选择的每页的行数（*）
            height:500,
            strictSearch: true,
            showColumns: true,                  //是否显示所有的列
            showRefresh: true,                  //是否显示刷新按钮            
            //paginationPreText: "上一页",
            //paginationNextText: "下一页",            
            paginationVAlign: "bottom",

            paginationHAlign: "right",                      
            clickToSelect: true,                //是否启用点击选中行
            //height: 500,                        //行高，如果没有设置height属性，表格自动根据记录条数觉得表格高度
            uniqueId: "id",                     //每一行的唯一标识，一般为主键列          
            onLoadSuccess: function(){  //加载成功时执行
                //alert("加载成功");
            },
            onLoadError: function(){  //加载失败时执行
               // alert("加载数据失败");
            },
            columns: [{
                checkbox: true
            }, {
                field: 'VistName',
                title: '来访者'
            }, {
                field: 'VistTel',
                title: '访客电话'
            }, {
                field: 'VistCompany',
                title: '来访者公司'
            }, {
                field: 'CarNo',
                title: '来访者车牌'
            }, {
                field: 'faceImg',
                title: '访客照片',
                formatter: function (value, row, index) {
                    var s;
                   
                    var url = row.faceImgUrl;
                    //var i = row.companyImage.indexOf("webapps");
                    //var url = row.companyImage.substring(i+7,row.companyImage.length);
                    //var url = 'F:\idnex.jpg';
                    s = '<a class = "view"  href="javascript:void(0)"><img style="width:300;height:40px;"  src="http://' + url + '" /></a>';
                   
                    return s;

                },

                //定义点击之后放大图片的事件
                events: 'operateEvents'
            }, {
                field: 'isAuthen',
                title: '是否有权'
            }, {
                field: 'isComing',
                title: '是否已来'
            }]
        });
    };

    //得到查询的参数
    oTableInit.queryParams = function (params) {       
        var temp = {   //这里的键的名字和控制器的变量名必须一直，这边改动，控制器也需要改成一样的
            pageSize : params.pageSize, 
            pageNumber : params.pageNumber,
           
            company: $("#txt_search_company").val(),
            name: $("#txt_search_name").val() 
        };


        return temp;
    };
    return oTableInit;
};


var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};

    oInit.Init = function () {
        //初始化页面上面的按钮事件
    };

    return oInit;
};
