import { Card, TypeCard } from '../Types';
import { cardsPlants as cardsPlants, cardsZombie as cardsZombie } from '../Cards';
import { action, makeObservable, observable } from 'mobx';
import '../../../components/Assets/table2.png';

// function getRandomInt(max) {
//     return Math.floor(Math.random() * max);
// }

class Game {
    isMyStep: boolean = false; // флаг, показывающий мой ли сейчас ход
    deckCardsPlants: Array<Card> = [];
    deckCardsZombie: Array<Card> = []; // карты в колоде
    //lot: Array<number> = [0, 1]; // жребий

    constructor() {
        makeObservable(this, {
            isMyStep: observable,
            deckCardsPlants: observable,
            deckCardsZombie: observable,
            //lot: observable,
            reduceCards: action,
        });
    }

    // Перемешать колоду
    mixDeck() {
        this.deckCardsPlants = this.deckCardsPlants.sort(() => Math.random() - 0.5);
        this.deckCardsZombie = this.deckCardsZombie.sort(() => Math.random() - 0.5);
    }

    // определение чей ход будет первый, жребий
    defineStep() {
        // var step = getRandomInt(1);
        // if (step < 1) {
        //     this.toggleStep();
        // }
    }

    // уменьшение количества карт общей колоды
    reduceCards(countCards: number, deck: Array<Card>): Array<Card> {
        const removedCard = deck.splice(0, countCards);

        return removedCard; // возвращает удаленные карты
    }

    // переключение хода
    toggleStep() {
        this.isMyStep = !this.isMyStep;
    }

    startGame() {
        this.deckCardsPlants = cardsPlants;
        this.deckCardsZombie = cardsZombie;
        this.mixDeck();

        const firstHisCards = this.reduceCards(5, this.deckCardsZombie);
        const firstMyCards = this.reduceCards(5, this.deckCardsPlants);

        this.defineStep();

        return { firstHisCards, firstMyCards };
    }

    /*
    addPlayersCards(my: any, his: any) {
        const myNeed = 5 - my.cards.length;
        const hisNeed = 5 - his.cards.length;
        my.addCards(this.reduceCards(myNeed > 0 ? myNeed : 0));
        his.addCards(this.reduceCards(hisNeed > 0 ? hisNeed : 0));
    }
    */
    /*
    setIsGetCard(isGetCard: boolean) {
        this.isGetCard = isGetCard;
    }
    */
}

export default Game;
