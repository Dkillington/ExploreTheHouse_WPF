   M S B A M L   `   `   `  ����F  BWPFTutorial, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFTutorialWPFTutorial  5   	   M+clr-namespace:WPFTutorial.View.UserControlsWPFTutorial.View.UserControls  5   	       WPFTutorial.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFTutorial     5   	   DuserControls+clr-namespace:WPFTutorial.View.UserControls     5   	     � Title$  Explore The House��5	   	   $
��1024��6#   $
��1024��61    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Styles.xaml?�6%   %    5      .��5      � -   5        $��MainGrid��5      .+�5   
   �� -   5        $��	screenImg��5      $��backgrounds/front.jpg��6#    K� ZIndex$ 0��6C   $
��Fill=�6T   0   *WPFTutorial.View.UserControls.InventoryBtn  5   
   -   5          Name$ invBtn��5   $   $��919,912,38,14q�64   $ 1��6K   $y�Visible=�6]   6t   -   'WPFTutorial.View.UserControls.LootPanel  5   
   -   5          Name$ 	lootPanel��5   !   $��234,265,230,211q�64   $ 2��6M   $y�Hidden=�6^   6t   -   'WPFTutorial.View.UserControls.Inventory  5   
   -   5          Name$	 inv��5   !   $��80,265,80,139q�6.   $ 3��6E   $y�Hidden=�6V   6l   �� 5   
   -   5        $��frontDoorBtn��5      $��469,412,465,457q�6A   $y�Hidden=�6Z      	Selection#��[  6n   �� 5   
   -   5        $��exitBtn��5      $��300,834,296,8q�66   $y�Hidden=�6M   #��[  6a   �� 5!   
   -   5        $��atticBtn��5!      $��512,470,405,344q�68   $y�Visible=�6Q   #��[  6f   �� 5"   
   -	   5        $��
kitchenBtn��5"      $��84,326,753,66q�6=   $y�Visible=�6T   #��[  6i   �� 5#   
   -
   5        $��
bedroomBtn��5#      $��728,429,188,162q�6=   $y�Visible=�6V   #��[  6k   �� 5$   
   -   5        $��leaveBtn��5$      $��451,897,363,0q�68   $y�Visible=�6O   #��[  6d   �� 5&   
   -   5        $��leaveKitchenBtn��5&      $��377,852,343,0q�6F   $y�Hidden=�6]   #��[  6q   �� 5(   
   -   5        $��leaveBedroomBtn��5(      $��377,852,343,0q�6G   $y�Hidden=�6^   #��[  6r   �� 5)   
   -   5        $��leaveTableBtn��5)      $��377,852,343,0q�6D   $y�Hidden=�6[   #��[  6o   �� 5*   
   -   5        $��leaveUnderbedBtn��5*      $��377,852,343,0q�6J   $y�Hidden=�6a   #��[  6u   �� 5+   
   -   5        $��boxBtn��5+      $��152,470,274,211q�66   $y�Hidden=�6O   #��[  6c   �� 5,   
   -   5        $��underbedBtn��5,      $��536,742,274,94q�6@   $y�Hidden=�6X   #��[  6l   �� 5-   
   -   5        $��grabNoteBtn��5-      $��144,234,110,299q�6@   $y�Hidden=�6Y   #��[  6m   �� 5.   
   -   5        $��sideTableBtn��5.      $��752,566,88,299q�6B   $y�Hidden=�6Z   #��[  6n   �� 50   
   -   5        $��leaveAtticBtn��50      $��326,834,343,0q�6C   $y�Hidden=�6Z   #��[  6n   �� 52   
   -   5        $��leaveBasementBtn��52      $��348,0,246,802q�6I   $y�Hidden=�6`   #��[  6t   54      55      