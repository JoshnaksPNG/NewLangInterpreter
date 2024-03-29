﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static NewLangInterpreter.src.Frontend.AST;

namespace NewLangInterpreter.src.Frontend
{
    internal class AST
    {
        public enum NodeType
        {
            // Statements
            Program,
            VarDeclaration,
            FunctionDeclaration,
            Return,
            IfStatement,
            IfElseStatement,
            WhileStatement,
            DoWhileStatement,
            ForStatement,

            // Literals
            IntLiteral,
            NullLiteral,
            Property,
            ObjectLiteral,
            StringLiteral,
            CharLiteral,
            FloatLiteral,
            BoolLiteral,
            ArrayLiteral,

            // Expressions
            Identifier,
            BinaryExpr,
            UnaryExpr,
            AssignmentExpr,
            MemberExpr,
            CallExper,
            IndexExpr,

            // Meta-Statements
            SetMutDefault,
            SetSilly,
        }

        public enum DataType
        {
            String,
            Char,
            Float,
            Int,
            Bool,

            Function,
            Object,
            Array,

            Null,

            Void,
        }

        public enum Operator
        {
            Add,
            Subtract,
            Multiply,
            Divide,
            Modulo,

            AddAssignment,
            SubtractAssignment,
            MultiplyAssignment,
            DivideAssignment,
            ModuloAssignment,

            Increment,
            Decrement,
            Exponentiate,

            LogicalAnd,
            LogicalOr,

            LogicalNot,

            GreaterThan,
            GreaterEqTo,
            LessThan,
            LessEqTo,
            EqualTo,
            NotEqualTo,

            Unknown,
        }

        public class Statement
        {
            public NodeType kind;
        }

        public class Expression : Statement
        {
            public DataType dataType = DataType.Null;
        }

        public class Program : Statement
        {
            public List<Statement> body;

            public Program()
            {
                kind = NodeType.Program;
                body = new List<Statement>();
            }

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", body: ";

                returned += body.ToString() + " }";

                return returned;
            }
        }

        public class VarDeclaration : Statement
        {
            public bool isConstant;

            public string identifier;

            public DataType dataType;

            public Expression? value;

            public bool is_default;

            public VarDeclaration(string ident, DataType dataType)
            {
                kind = NodeType.VarDeclaration;
                isConstant = false;
                is_default = true;
                identifier = ident;
                this.dataType = dataType;
                value = null;
            }

            public VarDeclaration(string ident, bool isConst, DataType dataType)
            {
                kind = NodeType.VarDeclaration;
                isConstant = isConst;
                identifier = ident;
                this.dataType = dataType;
                is_default = false;
                value = null;
            }

            public VarDeclaration(string ident, bool isConst, Expression val, DataType dataType)
            {
                kind = NodeType.VarDeclaration;
                isConstant = isConst;
                identifier = ident;
                value = val;
                this.dataType = dataType;
                is_default = false;
            }

            public VarDeclaration(string ident, Expression val, DataType dataType)
            {
                kind = NodeType.VarDeclaration;
                isConstant = false;
                identifier = ident;
                value = val;
                this.dataType = dataType;
                is_default = true;
            }

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", identifier: ";

                returned += identifier.ToString();

                if (value != null)
                {
                    returned += ", value: ";

                    returned += value.ToString();
                }

                returned += ", isConstant: ";

                returned += isConstant.ToString() + " }";

                return returned;
            }
        }

        public class ReturnStatement : Statement
        {
            public Expression? value;

            public ReturnStatement(Expression? value)
            {
                kind = NodeType.Return;
                if (value == null)
                {
                    this.value = null;
                    return;
                }
                this.value = value;
            }
        }

        public class FunctionDeclaration : Statement
        {
            // {identifier, datatype}
            public List<KeyValuePair<string, string>> parameters;

            public string name;

            public List<Statement> body;

            public DataType returnType;

            //public Expression? value;

            public FunctionDeclaration(string ident, List<Statement> body, List<KeyValuePair<string, string>> args, string ret_type)
            {
                kind = NodeType.FunctionDeclaration;
                name = ident;
                this.body = body;
                parameters = args;
                returnType = type_from_string(ret_type);
            }

            /*public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", name: ";

                returned += name.ToString();

                returned += ", value: ";

                returned += value.ToString();

                returned += ", isConstant: ";

                returned += isConstant.ToString() + " }";

                return returned;
            }*/
        }

        public class IfStatement : Statement
        {
            public List<Statement> body;
            public Expression condition;

            public IfStatement(List<Statement> body, Expression condition)
            {
                kind = NodeType.IfStatement;
                this.body = body;
                this.condition = condition;
            }

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", body: ";

                returned += body.ToString() + " }";

                return returned;
            }
        }

        public class IfElseStatement : Statement
        {
            public IfStatement ifstmt;
            public List<Statement> body;

            public IfElseStatement(IfStatement ifstmt, List<Statement> body)
            {
                kind = NodeType.IfElseStatement;
                this.body = body;
                this.ifstmt = ifstmt;
            }

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", body: ";

                returned += body.ToString() + " }";

                return returned;
            }
        }

        public class WhileStatement : Statement
        {
            public List<Statement> body;
            public Expression condition;

            public WhileStatement(List<Statement> body, Expression condition)
            {
                kind = NodeType.WhileStatement;
                this.body = body;
                this.condition = condition;
            }

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", body: ";

                returned += body.ToString() + " }";

                return returned;
            }
        }

        public class DoWhileStatement : Statement
        {
            public List<Statement> body;
            public Expression condition;

            public DoWhileStatement(List<Statement> body, Expression condition)
            {
                kind = NodeType.DoWhileStatement;
                this.body = body;
                this.condition = condition;
            }

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", body: ";

                returned += body.ToString() + " }";

                return returned;
            }
        }

        public class ForStatement : Statement
        {
            public List<Statement> body;
            public Expression condition;
            public Statement initial;
            public Expression repetand;

            public ForStatement(List<Statement> body, Expression condition, Statement initial, Expression repetand)
            {
                kind = NodeType.ForStatement;
                this.body = body;
                this.condition = condition;
                this.initial = initial;
                this.repetand = repetand;
            }

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", body: ";

                returned += body.ToString() + " }";

                return returned;
            }
        }

        public class AssignmentExpr : Expression
        {
            public Expression assignee;

            public Expression value;

            public AssignmentExpr(Expression assignee, Expression value)
            {
                kind = NodeType.AssignmentExpr;
                this.assignee = assignee;
                this.value = value;
            }

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();
                returned += ", identifier: ";

                returned += assignee.ToString();

                returned += ", value: ";

                returned += value.ToString() + " }";

                return returned;
            }
        }

        public class BinaryExpr : Expression
        {
            public BinaryExpr(Expression left, Expression right, Operator opr)
            {
                this.left = left;
                this.right = right;
                this.opr = opr;

                kind = NodeType.BinaryExpr;
            }

            public Expression left;
            public Expression right;
            public Operator opr;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", left: ";

                returned += left.ToString();

                returned += ", right: ";

                returned += right.ToString();

                returned += ", opr: ";

                returned += opr.ToString() + " }";

                return returned;
            }
        }

        public class CallExpr : Expression
        {
            public CallExpr(Expression callee)
            {
                args = new List<Expression>();
                this.callee = callee;

                kind = NodeType.CallExper;
            }

            public CallExpr(Expression callee, List<Expression> arg_list)
            {
                args = arg_list;
                this.callee = callee;

                kind = NodeType.CallExper;
            }

            public List<Expression> args;
            public Expression callee;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", callee: ";

                returned += callee.ToString();

                returned += ", args: ";

                returned += args.ToString() + " }";

                return returned;
            }
        }

        public class MemberExpr : Expression
        {
            public MemberExpr(Expression obj, Expression property, bool comp)
            {
                this.obj = obj;
                this.property = property;
                is_computed = comp;

                kind = NodeType.MemberExpr;
            }

            public Expression obj;
            public Expression property;
            public bool is_computed;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", obj: ";

                returned += obj.ToString();

                returned += ", property: ";

                returned += property.ToString();

                returned += ", is_computed: ";

                returned += is_computed.ToString() + " }";

                return returned;
            }
        }

        public class ArrayIndexExpr : Expression
        {
            public ArrayIndexExpr(Expression arr, Expression idx)
            {
                this.arr = arr;
                this.idx = idx;

                kind = NodeType.IndexExpr;
            }

            public Expression arr;
            public Expression idx;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", arr: ";

                returned += arr.ToString();

                returned += ", idx: ";

                returned += idx.ToString() + " }";

                return returned;
            }
        }

        public class UnaryExpr : Expression
        {
            UnaryExpr(Expression operand, Operator opr)
            {
                this.operand = operand;
                this.opr = opr;

                kind = NodeType.UnaryExpr;
            }

            Expression operand;
            Operator opr;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", operand: ";

                returned += operand.ToString();

                returned += ", opr: ";

                returned += opr.ToString() + " }";

                return returned;
            }
        }

        public class Identifier : Expression
        {
            public Identifier(string symbol)
            {
                this.symbol = symbol;

                kind = NodeType.Identifier;
            }

            public string symbol;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", symbol: ";

                returned += symbol.ToString() + " }";

                return returned;
            }
        }

        public class IntLiteral : Expression
        {
            public IntLiteral(int value)
            {
                kind = NodeType.IntLiteral;
                this.value = value;
            }

            public int value;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", value: ";

                returned += value.ToString() + " }";

                return returned;
            }
        }

        public class FloatLiteral : Expression
        {
            public FloatLiteral(float value)
            {
                kind = NodeType.FloatLiteral;
                this.value = value;
            }

            public float value;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", value: ";

                returned += value.ToString() + " }";

                return returned;
            }
        }

        public class StringLiteral : Expression
        {
            public StringLiteral(string value)
            {
                kind = NodeType.StringLiteral;
                this.value = value;
            }

            public string value;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", value: ";

                returned += value.ToString() + " }";

                return returned;
            }
        }

        public class CharLiteral : Expression
        {
            public CharLiteral(char value)
            {
                kind = NodeType.CharLiteral;
                this.value = value;
            }

            public char value;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", value: ";

                returned += value.ToString() + " }";

                return returned;
            }
        }

        public class BoolLiteral : Expression
        {
            public BoolLiteral(bool value)
            {
                kind = NodeType.BoolLiteral;
                this.value = value;
            }

            public bool value;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", value: ";

                returned += value.ToString() + " }";

                return returned;
            }
        }

        public class ObjectLiteral : Expression
        {
            public ObjectLiteral()
            {
                kind = NodeType.ObjectLiteral;
                properties = new List<Property>();
            }

            public ObjectLiteral(List<Property> properties)
            {
                kind = NodeType.ObjectLiteral;
                this.properties = properties;
            }

            public List<Property> properties;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", properties: [";

                foreach (Property property in properties)
                {
                    returned += property.ToString() + ", ";
                }

                returned += " ]}";

                return returned;
            }
        }

        public class ArrayLiteral : Expression
        {
            public ArrayLiteral()
            {
                kind = NodeType.ArrayLiteral;
                elements = new List<Expression>();
            }
            public ArrayLiteral(List<Expression> elements)
            {
                kind = NodeType.ArrayLiteral;
                this.elements = elements;
            }

            public List<Expression> elements;

            //public NodeType arrayType;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", elements: [";

                foreach (Expression element in elements)
                {
                    returned += element.ToString() + ", ";
                }

                returned += " ]}";

                return returned;
            }
        }

        public class Property : Expression
        {
            public Property(string key, Expression value, string type)
            {
                kind = NodeType.Property;
                this.key = key;
                this.value = value;
                dataType = type_from_string(type);
            }

            public string key;
            public Expression value;
            new public DataType dataType;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", key: ";

                returned += key.ToString();

                returned += ", value: ";

                if (value == null)
                {
                    returned += ", value: null }";
                }
                else
                {
                    returned += value.ToString() + " }";
                }

                return returned;
            }
        }

        public class NullLiteral : Expression
        {
            public NullLiteral()
            {
                kind = NodeType.NullLiteral;
                value = "null";
            }

            public string value;

            public override string ToString()
            {
                string returned = "{ kind: ";

                returned += kind.ToString();

                returned += ", value: ";

                returned += value.ToString() + " }";

                return returned;
            }
        }

        public class MetaStatement : Statement
        {

        }

        public class MutDefaultStatement : MetaStatement
        {
            public MutDefaultStatement(bool val)
            {
                kind = NodeType.SetMutDefault;
                is_immutable = val;
            }

            public bool is_immutable;
        }

        public class SillyDefaultStatement : MetaStatement
        {
            public SillyDefaultStatement()
            {
                kind = NodeType.SetSilly;
                val = true;
            }

            public bool val;
        }

        public static Operator operator_from_string(string val)
        {
            switch (val)
            {
                case "+":
                    return Operator.Add;

                case "-":
                    return Operator.Subtract;

                case "*":
                    return Operator.Multiply;

                case "/":
                    return Operator.Divide;

                case "%":
                    return Operator.Modulo;

                case "&&":
                    return Operator.LogicalAnd;

                case "||":
                    return Operator.LogicalOr;

                case "!":
                    return Operator.LogicalNot;

                case ">":
                    return Operator.GreaterThan;

                case "<":
                    return Operator.LessThan;

                case ">=":
                    return Operator.GreaterEqTo;

                case "<=":
                    return Operator.LessEqTo;

                case "==":
                    return Operator.EqualTo;

                case "!=":
                    return Operator.NotEqualTo;

                default:
                    Console.Error.WriteLine("Error! Unknown Operator: " + val);
                    Environment.Exit(0);
                    return Operator.Unknown;
            }
        }

        public static DataType type_from_string(string val)
        {
            switch (val)
            {
                case "int":
                    return DataType.Int;

                case "char":
                    return DataType.Char;

                case "float":
                    return DataType.Float;

                case "bool":
                    return DataType.Bool;

                case "string":
                    return DataType.String;

                case "obj":
                    return DataType.Object;

                case "func":
                    return DataType.Function;

                case "void":
                    return DataType.Void;

                default:
                    throw new Exception("Unrecognized Datatype!");
            }
        }
    }
}
