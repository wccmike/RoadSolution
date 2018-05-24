var Dept = {
	Tree: {
		ztree: null,
		init: function(treeObj, nodeClick){
			var setting = {
				view: {
					dblClickExpand: false,
					showLine: true,
					selectedMulti: false
				},
				data: {
					simpleData: {
						enable:true,
						idKey: "id",
						pIdKey: "pId",
						rootPId: ""
					}
				},
				callback: {
					beforeClick: function(treeId, treeNode) {
						nodeClick && nodeClick(treeNode);
					}
				}
			};

			

			var username=document.cookie.split(";")[0].split("=")[1];
			var zNodes =[
				//{ id:1, pId:0, name:"新城区", open:true},

				{ id:12, pId:1, name:"新城区", open:true},

					{ id:121, pId:12, name:"XX所"}, 
					{ id:122, pId:12, name:"XX所"}, 
					{ id:123, pId:12, name:"XX所"}
					
					
			];
			if(username != "ankang"){
				var zNodes =[
					//{ id:1, pId:0, name:"新城区", open:true},
					{ id:12, pId:1, name:"新城区", open:true},

					{ id:121, pId:12, name:"XX所"}, 
					{ id:122, pId:12, name:"XX所"}, 
					{ id:123, pId:12, name:"XX所"}
				];
			}
			

			this.ztree = $.fn.zTree.init(treeObj, setting, zNodes);
		},
		selectNode: function(id){
			this.ztree.selectNode(this.ztree.getNodeByParam("id", id));
		}
	}
};