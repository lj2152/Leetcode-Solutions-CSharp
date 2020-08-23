//https://leetcode.com/problems/serialize-and-deserialize-binary-tree/

public string serialize(TreeNode root) {

	return Serialize(root);
}

public string Serialize(TreeNode root) {
	var sb = new StringBuilder();
	var result = SerializeHelper(root, sb);

	//trim the extra comma at the end
	return result.ToString().Trim(',');
}

private StringBuilder SerializeHelper(TreeNode root, StringBuilder sb) {

	if (root == null) {
		sb.Append("null,");
	}
	else {
		sb.Append(root.val + ",");
		SerializeHelper(root.left, sb);
		SerializeHelper(root.right, sb);
	}

	return sb;
}

public TreeNode deserialize(string input) {
	var queue = new Queue <string> (input.Split(','));
	return DeserializeHelper(queue);
}

private TreeNode DeserializeHelper(Queue <string> strQueue) 
{
	if (strQueue.Peek().Equals("null"))
	{
		strQueue.Dequeue();
		return null;
	}
	
	int val = int.Parse(strQueue.Dequeue());
	var root = new TreeNode(val);
	
	root.left = DeserializeHelper(strQueue);
	root.right = DeserializeHelper(strQueue);
	
	return root;
}