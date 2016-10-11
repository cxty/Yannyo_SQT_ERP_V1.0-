function cavPublicBuild_Tree()
{
	this.PageTreeObj = null;
	this.t_Tree = new Array();
	this.pid = 0;
}
cavPublicBuild_Tree.prototype.ini = function(pNode,pLevel)
{
	if(pNode)
	{
		if(pNode.length>0)
		{
			for(var i=0;i<pNode.length;i++)
			{
				if(pNode[i].nodeName != '#text')
				{
					if(pNode[i].nodeName == 'Region_List')
					{
						if(Trim(GetXMLData(pNode[i],'RegionID'))!='')
						{
							var t_cID = GetXMLData(pNode[i],'RegionID');
							var t_cName = GetXMLData(pNode[i],'rName');
							var t_cUpID = GetXMLData(pNode[i],'rUpID');
							var t_cState = (GetXMLData(pNode[i],'rState') == '0') ? true : false;
							
							var t = new Tcxty_treeObj(t_cName, '', t_cState, null, '', '', t_cID, 'CheckTreeNode(this);','CheckTreeNodeState(this)','CheckTreeNodeAdd(this)','CheckTreeNodeDel(this)',null,null,'MoveFunction',this,'CheckTreeExpandNode(this)');
							this.t_Tree.push(new Array(t_cID,t_cName,t_cUpID,t));
							if(Number(Trim(t_cUpID)) == this.pid)
							{
								this.PageTreeObj.add(t);
								this.PageTreeObj.expand();
							}
							else
							{
								for(var k=0;k<this.t_Tree.length;k++)
								{
									if(this.t_Tree[k][0] == t_cUpID)
									{
										this.t_Tree[k][3].add(t);
										this.t_Tree[k][3].expand();
									}
								}
							}
							t_cState = null;
							t_cID = null;
							t_cName = null;
							t_cUpID = null;
						}
					}
					if(pNode[i].childNodes.length>0){
						if(pNode[i].nodeType==3) continue;
						this.ini(pNode[i].childNodes,pLevel+1);
					}
				}
			}
		}
	}
}
cavPublicBuild_Tree.prototype.Reini = function(nodes,leve)
{
	this.cls();
	this.ini(nodes,leve);
}
cavPublicBuild_Tree.prototype.cls = function()
{
	var i;
	
	for(i=0;i<this.t_Tree.length;i++)
	{	
		this.t_Tree[i][3]._remove();
	}
	webFXTreeHandler.idCounter = 4;
	i = null;
	this.t_Tree.length = 0;
	this.t_Tree = null;
	this.t_Tree = new Array;
}
cavPublicBuild_Tree.prototype.getCheckedValue = function(Obj)
{
	var tValue = '';
	var i;
	for(i=0;i<this.t_Tree.length;i++)
	{
		if(this.t_Tree[i][3].id == Obj)
		{
			tValue = this.t_Tree[i][3]._value;
		}
	}
	i = null;
	return tValue;
}
cavPublicBuild_Tree.prototype.getCheckedValueUp = function(Obj)
{
	var tValue = '';
	var i;
	for(i=0;i<this.t_Tree.length;i++)
	{
		if(this.t_Tree[i][3].id == Obj)
		{
			tValue = this.t_Tree[i][2];
		}
	}
	i = null;
	return tValue;
}