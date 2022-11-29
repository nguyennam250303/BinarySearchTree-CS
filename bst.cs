public class Program
{
    class Node
    {
        public Node left, right;
        public int val;
        public Node(int val)
        {
            this.val = val;
            left = right = null;
        }
    }
    class BinarySearchTree
    {
        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }
        public void insert(int newval)
        {
            Node cur = root;
            Node prev = null;
            Node newnode = new Node(newval);
            if (root == null)
            {
                root = newnode;
                return;
            }
            while(cur != null)
            {
                prev = cur;
                if (cur.val > newval)
                    cur = cur.left;
                else if (cur.val < newval)
                    cur = cur.right;
                else
                    return;
            }
            if (newval < prev.val)
                prev.left = newnode;
            if (newval > prev.val)
                prev.right = newnode;
        }
        public void traverseInOrder(Node node)
        {
            if (node == null)
                return;
            traverseInOrder(node.left);
            Console.Write(node.val + " ");
            traverseInOrder(node.right);
        }
        public void traversePreOrder(Node node)
        {
            if (node == null)
                return;
            Console.Write(node.val + " ");
            traversePreOrder(node.left);
            traversePreOrder(node.right);
        }
        public void traversePostOrder(Node node)
        {
            if (node == null)
                return;
            traversePostOrder(node.left);
            traversePostOrder(node.right);
            Console.Write(node.val + " ");
        }

        private int minValueOfNode(Node node)
        {
            if (node.left == null)
                return node.val;
            return minValueOfNode(node.left);
        }
        public int findMin()
        {
            return minValueOfNode(root);
        }
        private int maxValueOfNode(Node node)
        {
            if (node.right == null)
                return node.val;
            return minValueOfNode(node.right);
        }
        public int findMax()
        {
            return maxValueOfNode(root);
        }
        private int HeightOfTree(Node node)
        {
            if(node == null)
            {
                return 0;
            }
            return Math.Max(HeightOfTree(node.left), HeightOfTree(node.right)) + 1;
        }
        public int getHightOfNode()
        {
            return HeightOfTree(root);
        }
        private Node findNode(Node node, int val)
        {
            if (node != null)
            {
                if (node.val == val)
                    return node;
                else if (val < node.val)
                    return findNode(node.left, val);
                else
                    findNode(node.right, val);
            }
            return null;
        }
        public Node findNode(int val)
        {
            return this.findNode(root, val);
        }
        //public Node findNode(int val)
        //{
        //    Node cur = null;
        //    Queue<Node> mq = new Queue<Node> { };
        //    mq.Enqueue(root);
        //    while(mq.Count() != 0)
        //    {
        //        cur = mq.Peek();
        //        mq.Dequeue();
        //        if (cur != null)
        //        {
        //            if (val == cur.val)
        //                break;
        //            else if (val < cur.val)
        //                mq.Enqueue(cur.left);
        //            else
        //                mq.Enqueue(cur.right);
        //        }
        //    }
        //    return cur;
        //}
        private Node remove(Node node, int val)
        {
            if (node == null)
                return node;
            if (val < node.val)
                node.left = remove(node.left, val);
            else if (val > node.val)
                node.right = remove(node.right, val);
            else
            {
                if (node.left == null)
                    return node.right;
                if (node.right == null)
                    return node.left;
                node.val = minValueOfNode(node.right);
                node.right = remove(node.right, node.val);
            }
            return node;
        }
        public void remove(int val)
        {
            root = remove(root, val);
        }
    }
    static void Main()
    {

        BinarySearchTree bst = new BinarySearchTree();
        bst.insert(123);
        bst.insert(5);
        bst.insert(554);
        bst.insert(12);
        bst.insert(23);
        bst.insert(1);
        Console.WriteLine("traverseInOrder");
        bst.traverseInOrder(bst.root);
        Console.WriteLine("\ntraversePreOrder");
        bst.traversePreOrder(bst.root);
        Console.WriteLine("\ntraversePostOrder");
        bst.traversePostOrder(bst.root);
        Console.WriteLine("\nAfter delete");
        bst.remove(123);
        Console.WriteLine("traverseInOrder");
        bst.traverseInOrder(bst.root);
        Console.WriteLine("\ntraversePreOrder");
        bst.traversePreOrder(bst.root);
        Console.WriteLine("\ntraversePostOrder");
        bst.traversePostOrder(bst.root);
        Console.ReadLine();
    }
}
