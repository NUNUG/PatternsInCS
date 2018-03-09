using System;
using System.Text;

namespace Composite
{
	public class LiteralExpression: Expression
	{
		public string Value { get; set; }

		public LiteralExpression(string value)
		{
			this.Value = value;
		}

		public override string AsString()
		{
			return this.Value;
		}
	}

	// This is a composite type.  It's an expression that can contain inner expressions.
	public class NotExpression: Expression
	{
		public Expression ExpressionToNegate { get; set; }

		public NotExpression(Expression expressionToNegate)
		{
			this.ExpressionToNegate = expressionToNegate;
		}

		public override string AsString()
		{
			return($"(NOT {this.ExpressionToNegate.ToString()})");
		}
	}

	// This is a composite type.  It's an expression that can contain inner expressions.
	public enum ExpressionBinaryOperator { AND, OR, EQUALS, NOTEQUALS, LESSTHAN, GREATERTHAN, PLUS, MINUS, TIMES, DIVIDEDBY };
	public class BinaryExpression: Expression
	{
		public Expression LeftExpression { get; set; }
		public Expression RightExpression { get; set; }
		public ExpressionBinaryOperator BinaryOperator { get; set; }

		public BinaryExpression(Expression leftExpression, ExpressionBinaryOperator binaryOperator, Expression rightExpression)
		{
			this.LeftExpression = leftExpression;
			this.BinaryOperator = binaryOperator;
			this.RightExpression = rightExpression;
		}

		public override string AsString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("(");
			sb.Append(LeftExpression.ToString());
			switch (BinaryOperator)
			{
				case ExpressionBinaryOperator.AND: sb.Append(" AND "); break;
				case ExpressionBinaryOperator.OR: sb.Append(" OR "); break;
				case ExpressionBinaryOperator.EQUALS: sb.Append(" EQUALS "); break;
				case ExpressionBinaryOperator.NOTEQUALS: sb.Append(" NOTEQUALS "); break;
				case ExpressionBinaryOperator.LESSTHAN: sb.Append(" LESSTHAN "); break;
				case ExpressionBinaryOperator.GREATERTHAN: sb.Append(" GREATERTHAN "); break;
				case ExpressionBinaryOperator.PLUS: sb.Append(" PLUS "); break;
				case ExpressionBinaryOperator.MINUS: sb.Append(" MINUS "); break;
				case ExpressionBinaryOperator.TIMES: sb.Append(" TIMES "); break;
				case ExpressionBinaryOperator.DIVIDEDBY: sb.Append(" DIVIDEDBY "); break;
			}
			sb.Append(RightExpression.ToString());
			sb.Append(")");
			return sb.ToString();
		}
	}


	public abstract class Expression
	{
		public bool Negated { get; set; }
		public abstract string AsString();
		public override string ToString()
		{
			return this.AsString();
		}
	}
}