using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEscapeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Room currentRoom;

        public MainWindow()
        {
            InitializeComponent();
            // define rooms
            Room room1 = new Room("bedroom","I seem to be in a medium sized bedroom. There is a locker to the left, a nice rug on the floor, and a bed to the right. ");
            Room livingRoom = new Room("living room", "It is a bigger room, with a plant, a clock and a big closet. There is a door as well with a number lock on it. ");
            Room computerRoom = new Room("computer room", "It seems to be a medium room with a PC in there, there is a strange painting on the wall and a flag. ");

            // define items
            Item key1 = new Item("small silver key","A small silver key, makes me think of one I had at highschool. ", true);
            Item key2 = new Item("large key","A large key. Could this be my way out? ", true);
            Item locker = new Item("locker","A locker. I wonder what's inside. ", false);
            locker.HiddenItem = key2;
            locker.IsLocked = true;
            locker.Key = key1;

            Item bed = new Item("bed","Just a bed. I am not tired right now. ", false);
            Item chair = new Item("chair","Just a chair. I dont want to sit right now. ", false);
            Item poster = new Item("poster","Just a poster. Maybe there is something behind it? ", true);

            Item Plant = new Item("plant", "A nice and big plant. ", false);
            Item Closet = new Item("closet", "A big closet, maybe there is something in it ", false);
            Item Painting = new Item("painting", "Just a painting. Maybe there is something behind it? ", true);
            Item Clock = new Item("clock", "Just a clock. Maybe there is something behind it? ", false);
            Item Rug = new Item("rug", "Just a rug. Maybe there is something under it? ", false);

            Item Bin = new Item("bin", "Just a bin. Maybe there is something inside it? ", false);
            Item Flag = new Item("flag", "Just a flag. Maybe there is something behind it? ", false);
            Item Computer = new Item("computer", "Just a computer. Maybe there is something on it? ", false);

            bed.HiddenItem = key1;
            // setup room
            room1.Items.Add(new Item("floor mat","A bit ragged floor mat, but still one of the most popular designs. ", true)); 
            room1.Items.Add(bed);
            room1.Items.Add(chair);
            room1.Items.Add(poster);
            room1.Items.Add(locker);

            livingRoom.Items.Add(Plant);
            livingRoom.Items.Add(Closet);
            livingRoom.Items.Add(Painting);
            livingRoom.Items.Add(Clock);
            livingRoom.Items.Add(Rug);
            livingRoom.Items.Add(chair);

            computerRoom.Items.Add(Painting);
            computerRoom.Items.Add(chair);
            computerRoom.Items.Add(chair);
            computerRoom.Items.Add(chair);
            computerRoom.Items.Add(Bin);
            computerRoom.Items.Add(Flag);
            computerRoom.Items.Add(Computer);

            room1.add_src(@"/img/ss-bedroom.png");
            computerRoom.add_src(@"/img/ss-computer.png");
            livingRoom.add_src(@"/img/ss-living.png");

            // setup deuren
            Door BedroomToLiving = new Door("Door To Living","Door To Living", true, livingRoom);
            BedroomToLiving.Key = key2;

            Door LivingToBedroom = new Door("Door To Bedroom","Door To Bedroom", false, room1);

            Door LivingToComputer = new Door("Door To Computer","Door To Computer", false, computerRoom);
            Door ComputerToLiving = new Door("Door To Living","Door To Living", false, livingRoom);
            Door LivingToNull = new Door("Door To Outside","Door To Outside", true, null);

            // Deuren in kamers plaatsen
            room1.Doors.Add(BedroomToLiving);

            livingRoom.Doors.Add(LivingToBedroom);
            livingRoom.Doors.Add(LivingToComputer);
            livingRoom.Doors.Add(LivingToNull);

            computerRoom.Doors.Add(ComputerToLiving);
            // start game
            currentRoom = room1;
            lblMessage.Content = "I am awake, but cannot remember who I am!? Must have been a hell of a party last night... ";
            txtRoomDesc.Text = currentRoom.ToString();
            UpdateUI();

        }
        private void UpdateUI()
        {
            ImgRoom.Source = new BitmapImage(new Uri(currentRoom.ImgSrc, UriKind.RelativeOrAbsolute));
            lstRoomItems.Items.Clear();
            lstRoomsDoors.Items.Clear();
            foreach (Item itm in currentRoom.Items)
            {
                lstRoomItems.Items.Add(itm);
            }
            foreach (Door door in currentRoom.Doors)
            {
                lstRoomsDoors.Items.Add(door);
            }
        }
       /* public int FindItemIndex(string I_Name)
        {
            int i = 0;
            foreach (var item in currentRoom.Items)
            {
                if(item.Name == I_Name)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        public bool IsItemPickup (int I_Index)
        {
            if(I_Index != -1)
            {
                return currentRoom.Items[I_Index].IsPortable;
            }
            else
            {
                return false;
            }
        }*/
        private void lstRoomItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Find Item
            Item myItem = (Item)lstRoomItems.SelectedItem;
            //Check for btn's
            btnCheck.IsEnabled = lstRoomItems.SelectedValue != null; // room item selected
            btnPickUp.IsEnabled = lstRoomItems.SelectedValue != null && myItem.IsPortable; // room item selected
            if (lstRoomItems.SelectedValue != null && !myItem.IsPortable) lblMessage.Content = "Item can not be picked up!";
            btnUseOn.IsEnabled = lstRoomItems.SelectedValue != null && lstMyItems.SelectedValue != null; // room item     and picked up item selected
        }

        private void lstMyItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDrop.IsEnabled = lstMyItems.SelectedValue != null;
            btnUseOn.IsEnabled = lstRoomItems.SelectedValue != null && lstMyItems.SelectedValue != null; // room item     and picked up item selected
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            // 1. find item to check
            Item roomItem = (Item)lstRoomItems.SelectedItem;
            // 2. is it locked?
            if (roomItem.IsLocked)
            {
                lblMessage.Content = $"{roomItem.Desc}It is firmly locked. ";
                return;
            }
            // 3. does it contain a hidden item?
            Item foundItem = roomItem.HiddenItem;
            if (foundItem != null)
            {
                
                lblMessage.Content = RandomMessageGenerator.GetRandomMessage(RandomMessageGenerator.MessageType.found) + foundItem.ToString();
                lstMyItems.Items.Add(foundItem);
                roomItem.HiddenItem = null;
                return;
            }
            // 4. just another item; show description
            lblMessage.Content = roomItem.Desc;

        }
        private void btnUseOn_Click(object sender, RoutedEventArgs e)
        {
            // 1. find both items
            Item myItem = (Item)lstMyItems.SelectedItem;
            Item roomItem = (Item)lstRoomItems.SelectedItem;

            // 2. item doesn't fit
            if (roomItem.Key != myItem)
            {
                lblMessage.Content = RandomMessageGenerator.GetRandomMessage(RandomMessageGenerator.MessageType.error);
                return;
            }

            // 3. item fits; other item unlocked
            roomItem.IsLocked = false;
            roomItem.Key = null;
            lstMyItems.Items.Remove(myItem);
            lblMessage.Content = $"I just unlocked the {roomItem.ToString()}!";
        }

        private void btnPickUp_Click(object sender, RoutedEventArgs e)
        {
            // 1. find selected item
            Item selItem = (Item)lstRoomItems.SelectedItem;

            // 2. add item to your items list
            string out6 = RandomMessageGenerator.GetRandomMessage(RandomMessageGenerator.MessageType.pickup) + selItem.ToString();
            lblMessage.Content = out6;
            lstMyItems.Items.Add(selItem);
            lstRoomItems.Items.Remove(selItem);
            currentRoom.Items.Remove(selItem);

        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            Item selItem = (Item)lstMyItems.SelectedItem;

            // 2. add item to your items list
            lblMessage.Content = $"I just droped up the {selItem.ToString()}. ";
            lstMyItems.Items.Remove(selItem);
            lstRoomItems.Items.Add(selItem);
            currentRoom.Items.Add(selItem);
        }

        private void btnOpenWith_Click(object sender, RoutedEventArgs e)
        {
            // 1.find both items
            Item myItem = (Item)lstMyItems.SelectedItem;
            Door door = (Door)lstRoomsDoors.SelectedItem;

            // 2. item doesn't fit
            if (door.Key != myItem)
            {
                lblMessage.Content = RandomMessageGenerator.GetRandomMessage(RandomMessageGenerator.MessageType.error);
                return;
            }

            // 3. item fits; other item unlocked
            door.IsLocked = false;
            door.Key = null;
            lstMyItems.Items.Remove(myItem);
            lblMessage.Content = $"I just unlocked the {door.ToString()}!";
            btnEnter.IsEnabled = true;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Door door = (Door)lstRoomsDoors.SelectedItem;
            currentRoom = door.LeadsTo;
            lblMessage.Content = $"I just entered the {currentRoom.ToString()}!";
            UpdateUI();

        }

        private void lstRoomsDoors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Find Door
            Door selectedDoor = (Door)lstRoomsDoors.SelectedItem;
            //Check Buttons
            btnOpenWith.IsEnabled = lstMyItems.SelectedItem != null && lstRoomsDoors.SelectedItem != null && selectedDoor.IsLocked;
            btnEnter.IsEnabled = lstRoomsDoors.SelectedItem != null && selectedDoor.IsLocked == false;
        }

        private void lstRoomsDoors_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            lstRoomsDoors.SelectedIndex = -1;
        }
    }
}
