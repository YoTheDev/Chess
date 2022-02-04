using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIBrain {

    public Board Board;
    public PlayerColor Player;
    public int DepthSearch;
    
    private List<Tuple<int, Node>> Nodes = new List<Tuple<int, Node>>();

    public AIBrain(Board board, PlayerColor player, int depthSearch) {
        Board = board;
        Player = player;
        DepthSearch = depthSearch;
    }

    public void Think() {
        Nodes.Clear();
        float startingTime = Time.realtimeSinceStartup;
        foreach (Piece availablePiece in Board.AvailablePieces(Player)) {
            foreach (Coordinate availableMove in availablePiece.AvailableMoves(Board)) {
                Node node = new Node(Board, Player, Player, availablePiece.CurrentCoordinate, availableMove);
                int value = MinMax(node, DepthSearch, false);
                Nodes.Add(new Tuple<int, Node>(value, node));
            }
        }
        Debug.Log("Reflexion took about : " + (Time.realtimeSinceStartup - startingTime) + " seconds");
    }

    public void Act() {
        if (Nodes.Count == 0) throw new Exception("MinMax results is empty");
        int bestValue = Nodes.Max(node => node.Item1);
        Nodes.RemoveAll(node => node.Item1 < bestValue);
        Tuple<int, Node> selectedTuple = Nodes[Random.Range(0, Nodes.Count)];
        Board.GetPiece(selectedTuple.Item2.MoveOrigin).ExecuteMove(Board, selectedTuple.Item2.MoveDestination);
    }
    
    private int MinMax(Node node, int depth, bool isMax) {
        if (depth == 0) {
            return node.Children.Count(); 
        }
        if (isMax) {
            float Value = -Mathf.Infinity;
            foreach (var child in node.Children) {
                Value = Mathf.Max(Value, MinMax(child, depth - 1, false));
            }
        }
        else {
            float Value = +Mathf.Infinity;
            foreach (var child in node.Children) {
                Value = Mathf.Min(Value, MinMax(child, depth - 1, true));
            }
        }
        return Nodes.Count;
    }
}