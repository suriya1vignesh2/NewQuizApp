   M S B A M L   `   `   `  ����B  >QuizAPP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:QuizAPP.ViewQuizAPP.View  5      !clr-namespace:QuizAPPQuizAPP  5      1clr-namespace:QuizAPP.ControlQuizAPP.Control  5	          QuizAPP.View.TestView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:QuizAPP.View     5      &Mainclr-namespace:QuizAPP     5      2Controlsclr-namespace:QuizAPP.Control     5	      .��5      �   � RowDefinitions  5   
   �� 5      $��1* �6   6*   �� 5      6   �� 5      $��5* �6   6*   �� 5      6   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      6!   �� 5      $��5* �6   6,   �� 5      6!   �� 5      $��1* �6   6,   .+�5   
   (� $��0��6   $��2��6   $��Stretch=�6/   $��Stretch=�6K   .��5      �� $
��Quiz��6   6%   5      .   (QuizAPP.Control.QuestionsFlipViewControl  5   
   $��	0,10,0,10q�6�   $��1��6�   $��1��6�   $��2��6  $��3��6    �� SelectedIndex 6,   �� *SelectedQutionIndex+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=���6�   �� *QuestionList+$ PropertyChanged=�$ TwoWay=�67  �� 5    
   $��Previous��6   $��3��6�   $��1��6�   ��6$   ��  �� Path$) #DataContext.PreviousQuestionCommand�$ PropertyChanged=� �� RelativeSource �� *FindAncestor+ �� AncestorType   QuizAPP.MainWindow"  6�   �� 5!   
   $
��Next��6   $��3��6  $��3��6!  ��6    �� $% DataContext.NextQuestionCommand�$ PropertyChanged=� �� *FindAncestor+"  ��6�   ��  �� ElementName$ QuestionsFlipViewControl��63  �� 5"   
   $
��Skip��6   $��3��6�   $��5,0,5,5q�6�   $��4��6�   ��6    �� $ DataContext.SkipCommand�$ PropertyChanged=� �� *FindAncestor+"  6�   �� 5#   
   $��Submit��6   $��4��6�   $��5,5,5,5q�6�   $��3��6�   ��6"   �� $ DataContext.SubmitCommand�$ PropertyChanged=� �� *FindAncestor+"  6�   � 5%   
   $��4��6   $��2��6   .+�5'      � -   5        $��pbStatus��5'   6   	 � Minimum$	 0Q�6   
 � Maximum$	
 100Q�6(   $��5,5,5,5q�6�    � Value 6G   �� *CurrentProgressValue+$ PropertyChanged=�6�   �� 5(      $��Center=�6c   $��Center=�6�   ��6   �� $ pbStatus��$ Value� �� StringFormat$ {0:0}%��6�   5)      �� 5*   
   $��5��6   $��2��6   $��Center=�6.   $��12(�6K   
���  ��$��Center=�6j   ��6�   �� *Time+$ PropertyChanged=�6�   5+   
   5,      