   M S B A M L   `   `   `  ����B  >QuizAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuizAPP.ViewQuizAPP.View  5      !clr-namespace:QuizAPPQuizAPP  5          QuizAPP.View.ResultView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:QuizAPP.View     5      &Mainclr-namespace:QuizAPP     5      .��5
      �   � RowDefinitions  5   
   �� 5      6   �� 5      6   �� 5      6   .+�5   
   (� .��5      �� $��Center=�6   $��Center=�66    �� Orientation$ Vertical=�6Q   .+�5      �� $��Result��6   6+   �� 5      $ 
Horizontal=�6   .+�5      �� $��Test Date :��6   5      �� 5      ��6   �� *
DateString+ �� UpdateSourceTrigger$ PropertyChanged=�6a   5      5      5      (� 5   
   $��1��6   .��5      �� ��6   �� *ResultSummary+$ PropertyChanged=���5      �� 5       �� 
TargetType" ��6   .�5       ��  �� Property � �� �� Value
 �  ��6E    �� Triggers 5!      �� 5"       �� Binding 6*   ��  �� Path$ IsPass�$ PropertyChanged=�	 �� Value	 True6n   .a�5#   "   ��  � ��
 � � �6O   5$      5'      5)      5*      �� 5+   
   $��25��6   $��50��6   $��Close��6�   $��Center=�6�   $��Center=�6�   $��2��6  ��6(   �� $ DataContext.CloseCommand�$ PropertyChanged=�
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType   QuizAPP.MainWindow"  5,      5-      5.      