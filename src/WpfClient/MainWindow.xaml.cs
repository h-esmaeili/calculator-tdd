﻿using Calculator.Wpf.Operations;
using Calculator.Wpf.ViewModels;
using System.Windows;

namespace Calculator.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CalcViewModel state;

        public MainWindow()
        {
            InitializeComponent();

            state = new CalcViewModel();

            this.KeyDown += (s, e) => state.KeyCodeEnterred(e.Key);

            Button_SplitNum.Click += (s, e) => state.AddOperation(new OperationCalcSplitNum());
            Button_AC.Click += (s, e) => state.AddOperation(new OperationClear());
            Button_SplitEq.Click += (s, e) => state.AddOperation(new OperationCalcSplitEq());
            Button_Dot.Click += (s, e) => state.AddOperation(new OperationAddDotText());

            Button_Add.Click += (s, e) => state.AddOperation(new OperationCalcAdd());
            Button_Minus.Click += (s, e) => state.AddOperation(new OperationCalcSubtract());
            Button_Multiply.Click += (s, e) => state.AddOperation(new OperationCalcMultiply());
            Button_Divide.Click += (s, e) => state.AddOperation(new OperationCalcDivide());
            Button_Equals.Click += (s, e) => state.AddOperation(new OperationCalcEquals());

            Button_0.Click += (s, e) => state.AddOperation(new OperationAppendText("0"));
            Button_1.Click += (s, e) => state.AddOperation(new OperationAppendText("1"));
            Button_2.Click += (s, e) => state.AddOperation(new OperationAppendText("2"));
            Button_3.Click += (s, e) => state.AddOperation(new OperationAppendText("3"));
            Button_4.Click += (s, e) => state.AddOperation(new OperationAppendText("4"));
            Button_5.Click += (s, e) => state.AddOperation(new OperationAppendText("5"));
            Button_6.Click += (s, e) => state.AddOperation(new OperationAppendText("6"));
            Button_7.Click += (s, e) => state.AddOperation(new OperationAppendText("7"));
            Button_8.Click += (s, e) => state.AddOperation(new OperationAppendText("8"));
            Button_9.Click += (s, e) => state.AddOperation(new OperationAppendText("9"));

            this.DataContext = state;
        }
    }
}