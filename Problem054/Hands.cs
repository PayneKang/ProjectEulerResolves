using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem054
{
    public class Hands
    {
        public static Dictionary<char, int> CARDVAL = new Dictionary<char, int>();
        static Hands()
        {
            CARDVAL.Add('2', 2);
            CARDVAL.Add('3', 3);
            CARDVAL.Add('4', 4);
            CARDVAL.Add('5', 5);
            CARDVAL.Add('6', 6);
            CARDVAL.Add('7', 7);
            CARDVAL.Add('8', 8);
            CARDVAL.Add('9', 9);
            CARDVAL.Add('T', 10);
            CARDVAL.Add('J', 11);
            CARDVAL.Add('Q', 12);
            CARDVAL.Add('K', 13);
            CARDVAL.Add('A', 14);
        }
        public Card[] Cards { get; set; }
        public HandType HandType { get; set; }
        public GroupCards FourValue { get; set; }
        public GroupCards ThreeValue { get; set; }
        public GroupCards[] PairValues { get; set; }
        public GroupCards[] SingleValues { get; set; }
        public Hands(string cardsStr)
        {
            // 8C TS KC 9H 4S
            string[] cardArray = cardsStr.Trim().Split(' ');
            if (cardArray.Length != 5)
                throw new Exception("Hand cards error");
            this.Cards = CreateCards(cardArray);
            GroupCards[] gc = GroupCards(this.Cards);
            bool sameColor = CheckSameColor(this.Cards);
            SetHandType(gc, sameColor);
        }
        private void SetHandType(GroupCards[] gc, bool sameColor)
        {            
            // Get 4 value
            this.FourValue = gc.SingleOrDefault(x=>x.CardCount == 4);
            // Get 3 value
            this.ThreeValue = gc.SingleOrDefault(x=>x.CardCount == 3);
            // Get 2 values
            this.PairValues = gc.Where(x=>x.CardCount == 2).OrderByDescending(x=>x.CardNumber).ToArray();
            // Get 1 values
            this.SingleValues = gc.Where(x=>x.CardCount == 1).OrderByDescending(x=>x.CardNumber).ToArray();
            // Four of a kind
            if(this.FourValue != null){
                this.HandType = HandType.FourOfAKind;
                return;
            }
            // Full House
            if(this.ThreeValue != null && this.PairValues.Count() == 1){
                this.HandType = HandType.FullHouse;
                return;
            }
            // Three of a kind
            if(this.ThreeValue != null && this.PairValues.Count() == 0){
                this.HandType = HandType.ThreeOfAKind;
                return;
            }
            // Two pairs
            if(this.PairValues.Count() == 2){
                this.HandType = HandType.TwoPairs;
                return;
            }
            // One pair
            if(this.PairValues.Count() == 1 && this.ThreeValue == null){
                this.HandType = HandType.OnePair;
                return;
            }
            // Flush & High card
            if (gc.Count() == 5)
            {
                int diff = 1;
                GroupCards tempgc = new GroupCards();
                for (int i = 0; i < gc.Count(); i++)
                {
                    if (i == 0)
                    {
                        tempgc = gc[i];
                        continue;
                    }
                    diff = gc[i].CardNumber - tempgc.CardNumber;
                    tempgc = gc[i];
                    if (diff != 1)
                    {
                        if (sameColor)
                        {
                            this.HandType = HandType.Flush;
                            return;
                        }
                        this.HandType = HandType.HighCard;
                        return;
                    }
                }
                // Royal flush
                if (sameColor && gc[0].CardNumber == 10)
                {
                    this.HandType = HandType.RoyalFlush;
                    return;
                }
                // Straight flush && straight
                if (sameColor)
                {
                    this.HandType = HandType.StraightFlush;
                    return;
                }
                else
                {
                    this.HandType = HandType.Straight;
                    return;
                }
            }
            throw new Exception("Unknown hand type");
        }

        private Card[] CreateCards(string[] cards)
        {
            Card[] result = new Card[cards.Length];
            for (int i = 0; i < cards.Length; i++)
            {
                string card = cards[i];
                if (card.Length != 2)
                {
                    throw new Exception("Card error");
                }
                result[i] = new Card()
                {
                    Color = card[1],
                    Number = CARDVAL[card[0]],
                    Value = card
                };
            }
            return result;
        }
        private bool CheckSameColor(Card[] cards)
        {
            return cards.GroupBy(x => x.Color).Count() == 1;
        }
        private GroupCards[] GroupCards(Card[] cards)
        {
            return cards.GroupBy(x => x.Number).Select(x => new GroupCards() { CardCount=x.Count(), CardNumber = x.FirstOrDefault().Number }).OrderBy(x=>x.CardNumber).ToArray();
        }
        public static int Compair(Hands handOne, Hands handTwo)
        {
            // Compair hand type
            int typeCompair = CompairType(handOne, handTwo);
            if(typeCompair != 0)
                return typeCompair;
            // Compair Royal Flush
            if (handOne.HandType == HandType.RoyalFlush)
                return 0;
            // Compair Straight flush
            if (handOne.FourValue != null && handTwo.FourValue != null)
            {
                if (handOne.FourValue.CardNumber > handTwo.FourValue.CardNumber)
                    return 1;
                if (handOne.FourValue.CardNumber < handTwo.FourValue.CardNumber)
                    return -1;
            }
            if (handOne.ThreeValue != null && handTwo.ThreeValue != null)
            {
                if (handOne.ThreeValue.CardNumber > handTwo.ThreeValue.CardNumber)
                    return 1;
                if (handOne.ThreeValue.CardNumber < handTwo.ThreeValue.CardNumber)
                    return -1;
            }
            if (handOne.PairValues != null && handTwo.PairValues != null)
            {
                if (handOne.PairValues.Count() == handTwo.PairValues.Count())
                {
                    for (int i = 0; i < handOne.PairValues.Count(); i++)
                    {
                        if (handOne.PairValues[i].CardNumber > handTwo.PairValues[i].CardNumber)
                            return 1;
                        if (handOne.PairValues[i].CardNumber < handTwo.PairValues[i].CardNumber)
                            return -1;
                    }
                }
            }

            if (handOne.SingleValues != null && handTwo.SingleValues != null)
            {
                if (handOne.SingleValues.Count() == handTwo.SingleValues.Count())
                {
                    for (int i = 0; i < handOne.SingleValues.Count(); i++)
                    {
                        if (handOne.SingleValues[i].CardNumber > handTwo.SingleValues[i].CardNumber)
                            return 1;
                        if (handOne.SingleValues[i].CardNumber < handTwo.SingleValues[i].CardNumber)
                            return -1;
                    }
                }
            }
            return 0;
        }
        public static int CompairType(Hands handOne, Hands handTwo)
        {
            if (handOne.HandType > handTwo.HandType)
                return 1;
            if (handTwo.HandType > handOne.HandType)
                return -1;
            return 0;
        }

    }
}
