   M S B A M L   `   `   `  ����R  NMiracle.Desktop.Toolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Miracle.Desktop.ToolkitMiracle.Desktop.Toolkit  5      S.clr-namespace:Miracle.Desktop.Toolkit.Controls Miracle.Desktop.Toolkit.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NMicrosoft.Windows.Shell, Version=3.0.1.0, Culture=neutral, PublicKeyToken=null  �� MergedDictionaries �� Source3    -Miracle.Desktop.Toolkit.Controls.ModernWindow �� 
TargetType �� Property   WindowBackgroundContent �� Value  DefaultFontFamily  DefaultFontSize  
WindowText  WindowBorder&   System.Windows.Media.TextOptions �� 
TargetType ��Name  WindowBackgroundColor �� Color � 	Resources  Key	 �� 
TargetName
 �� TargetProperty	 �� To g� Duration �Name � RowDefinitions    BackgroundContent � ColumnDefinitions � Title  ModernWindowTitle    IsTitleVisible � DataContext   BooleanToVisibilityConverter �� 	Converter    
TitleLinks*  $Microsoft.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome �� Orientation ��Name	 �� X1	 �� Y1	 �� X2	 �� Y2 	 SeparatorBackground 
 SystemButtonLink �� ElementName �� Triggers �� Binding  �� RelativeSource! �� Value" �� 
TargetName 
 Accent#    LogoData  NullToVisibilityConverter$ �� ConverterParameter% �� Stretch'   !Miracle.Desktop.Toolkit.Resources&   Minimize' � ToolTip  SystemButton,  &Microsoft.Windows.Shell.SystemCommands(   MinimizeWindowCommand) �� Source* �� Mode+ �� AncestorType, ��Name-   Restore.   RestoreWindowCommand/ � UseLayoutRounding0   Maximize1   MaximizeWindowCommand2   Close  SystemCloseButton3   CloseWindowCommand3   -Miracle.Desktop.Toolkit.Controls.ModernButton4   EllipseDiameter5   	IconWidth6   
IconHeight7   IconData8   Back1   +Miracle.Desktop.Toolkit.Controls.ModernMenu9    MenuLinkGroups:   
LinkGroups;   SelectedSource< �� Mode2   ,Miracle.Desktop.Toolkit.Controls.ModernFrame=  Name>    ContentLoader?   ContentLoader@   SourceA �� TriggersB P� PropertyC P� Value  WindowBorderActiveD   CornerRadiusE   GlassFrameThickness�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8mm1http://schemas.misfit.themes.com/wpf/xaml/toolkit  5      Kshell?http://schemas.microsoft.com/winfx/2006/xaml/presentation/shell  5      /local%clr-namespace:Miracle.Desktop.Toolkit  5      ;controls.clr-namespace:Miracle.Desktop.Toolkit.Controls  5        5      �� 5	   
   $; 5/Miracle.Desktop.Toolkit;component/Assets/Button.xaml?�6   �� 5
   
   $? 9/Miracle.Desktop.Toolkit;component/Assets/Converters.xaml?�6   �� 5   
   $> 8/Miracle.Desktop.Toolkit;component/Assets/TextBlock.xaml?�6   %  '         7  7  7 
 7  7  7  7  7  �� 5      "   6   .�5   
   ��  �@  BackgroundContent# �   6.   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6%   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6(   �� 5   
    � ��$	 800��6"   �� 5   
    � ��$	 640��6#   �� 5   
    � ��$	 320��6%   �� 5   
    � ��$	 320��6&   �� 5   
    �@�UseLayoutRounding . 6.   �� 5   
    �@ TextFormattingMode$ Display=�6;   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� $ WindowBorder��6   $��0q�63   ��5      �� 5      WindowBorderBackground��# �  6N    5!      ���� 5"      BackgroundAnimation .��5#   "   �� $	 WindowBorderBackground��61   $
 Color�6`   # �  6�   $ 0:0:.6D�6�   5$      5%      ._�5'      �� #��z��6!   $��1q�6M   ._�5(      �� .u�5)   "   � $ 
LayoutRoot��6'    5*   &   �� 5+   *   $��36 �68   �� 5,   *   $
��Auto �68   �� 5-   *   $��* �68   .+�51   &   �� $��5��65   #��z 6F   � 54   &    55   *   �� 56   .   $��* �6?   �� 57   .   $
��Auto �6?   �� 58   .   $
��Auto �6?   �� 59   .   $��96 �6?   .+�5=   *   �� #��z 64   $	��8,0q�6S   $��Center=�6`   8��  # z 5>   4   y�5?   4   �� 8  �� 5B   *   $��1��67   #��z 6G   $��0,0,24,0q�6r    . ��5C   .   �� 5D   2   .R�5E   6   �� $ 
Horizontal=�6A   5F   3   ��5H   .   �� 5I   2   .R�5J   6   �� $ 
Horizontal=�6A   .+�5K   :   �� $ 	Separator��6?   $ .5��6R   $ 3��6Z   $ .5��6a   $ 12��6i   $	��5,0q�6q   $��Center=�6~   #��� 	 6�   �� 5M   :   $"��mm:LinkCommands.NavigateLink��5N   A   8�� ��5M   A   �� *DisplayName+��5O   A   �� *Source+��5P   A   �� $ ContentFrame��5Q   A   5R   7    5S   6   �� 5T   :    6F   ��   �� *PreviousData+! 6�   Z� .a�5U   >   �� $" 	Separator��6[    � y�$ 	Collapsed=�6r   5V   ;   5X   3   5Z   +   �� 5]   *   $��2��61   #���  6A   $��36��6g   $��36��6r   $	��8,0q�6~   # z# 5^   1   y�5_   1   �� 8  $$ inverse��._�5`   .   F� $
% Fill=�6D   
�������$��24��6`   $��24��6k   $��Center=�6w   $��Center=�6�   ��63   �� 6�   5a   +   �� 5d   *   $��3��65   $ 
Horizontal=�6E   $	��Top=�6^    . .+�5e   .   �� #' Z& 6�   8�� ��65   �� #) Z( ��5f   2   � 5g   6   $��13��6;   $��12��6F   $z�1,0,0,1,0,1W�6R   .+�5h   :   F� ����    ��[ � z ��[ 	$��8��6R   $��7��6\   $��Center=�6g   $��Center=�6�   $��2��5i   �   ��6?   �� *
Foreground+  �� $* FindAncestor=�$+ ButtonL�6�   5j   7   5l   /   � 5m   .   $��1,0,1,0q�63   .+�5n   2   �� $, Restore��69   #' Z- 6�   8�� $y�	Collapsed=�6�   ��6J   �� #) Z. ��5o   6   � 5p   :   $��13��6?   $��12��6J   / . $z�1,0,0,1,.5,.5W�6o   .+�5q   >   F� X���Ѐ�     � z     � z ��[ �    ��- р�[ ��- �    �� р�[ �� р�[  z �     z 	$��8��6y   $��8��6�   $��Center=�6�   $��Center=�6�   $��1��5r   �   ��6C   �� *
Foreground+  �� $* FindAncestor=�$+ ButtonL�6�   5s   ;   5u   3   �� 5v   2   $, Maximize��69   #' Z0 6�   8�� ��6K   �� #) Z1 ��5w   6   � 5x   :   $��13��6?   $��12��6J   .+�5y   >   F� +����    @B �@T� @B �@T�  z �     z 	$��9��6`   $��8��6j   $��Center=�6u   $��Center=�6�   $��2��5z   �   ��6C   �� *
Foreground+  �� $* FindAncestor=�$+ ButtonL�6�   5{   ;   5}   3   5~   /   �� 5   .   #' Z2 6�   8�� ��65   �� #) Z3 ��5�   2   � 5�   6   $��13��6;   $��12��6F   $z�1,0,0,1,0,1W�6R   .+�5�   :   F� +����        � z ��j � z     �    ��j 	$��8��6\   $��7��6f   $��Center=�6q   $��Center=�6�   $	��1.5��5�   �   ��6?   �� *
Foreground+  �� $* FindAncestor=�$+ ButtonL�6�   5�   7   5�   /   5�   +   5�   '   � 5�   &   $��1��6+    5�   *   �� 5�   .   $��42 �6?   �� 5�   .   $��* �6?   .+�5�   *     $��8,10,0,0q�6@   $
��Left=�6R   $	��Top=�6m   $4 24Q�5�   @   $5 12Q�6U   $6 12Q�6d   a7 ��@����O�@������p\-�������@��� �8@����ا  6n� �8��� ������� �p\-��O�@����O$#��NavigationCommands.BrowseBack��5�   @   #' Z8 5�   @    . ��5�   @   �� $ ContentFrame��5�   @     5�   *   $��1��6>   #: z9 5�   >   ; 5�   >   �� *Source+$ ContentFrame��$< TwoWay=�5�   >   5�   '     5�   &   $= ContentFrame��6;   $��3��6Q   $��2��6^   $��
42,8,16,16q�6o   #? z> 6�   @ 6�   �� *ContentSource+  �� *TemplatedParent+$< TwoWay=�6�   5�   #   5�      5�      5�      A 5�      P� 5�      B �@�IsActiveC . . �5�      �� # �  6<    � ��5�      P� 5�      B �@�WindowState$C 	Maximized=�69   . �5�      �� $" Maximize��6%    � y�$ 	Collapsed=�6Q   �� 5�      $" Restore��6%    � y�$ Visible=�6P   �� 5�      $" 
LayoutRoot��6%    � ��$ 7q�6O   5�      P� 5�      B �@�WindowState$C Normal=�69   . �5�      �� $" Maximize��6%    � y�$ Visible=�6Q   �� 5�      $" Restore��6%    � y�$ 	Collapsed=�6P   5�      5�      5�      �� 5�   
    �@ WindowChrome 5�        5�      $D 0��6%   $E 1q�66   5�      5�      5�      