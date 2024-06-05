import { Card, TypeCard } from '../Types';
import { cards as allCards, cards } from '../Cards';
import { action, makeObservable, observable } from 'mobx';
import '../../../components/Assets/table2.png';

// function getRandomInt(max) {
//     return Math.floor(Math.random() * max);
// }

class Game {
    isMyStep: boolean = false; // флаг, показывающий мой ли сейчас ход
    deckCards: Array<Card> = []; // карты в колоде
    //lot: Array<number> = [0, 1]; // жребий

    constructor() {
        makeObservable(this, {
            isMyStep: observable,
            deckCards: observable,
            //lot: observable,
            reduceCards: action,
        });
    }

    // Перемешать колоду
    mixDeck() {
        this.deckCards = this.deckCards.sort(() => Math.random() - 0.5);
    }

    // определение чей ход будет первый, жребий
    defineStep() {
        // var step = getRandomInt(1);
        // if (step < 1) {
        //     this.toggleStep();
        // }
    }

    // уменьшение количества карт общей колоды
    reduceCards(countCards: number): Array<Card> {
        const removedCard = this.deckCards.splice(0, countCards);

        return removedCard; // возвращает удаленные карты
    }

    // переключение хода
    toggleStep() {
        this.isMyStep = !this.isMyStep;
    }

    startGame() {
        this.deckCards = allCards;
        this.mixDeck();

        const firstHisCards = this.reduceCards(5);
        const firstMyCards = this.reduceCards(5);

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
