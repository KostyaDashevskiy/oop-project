import { makeObservable, observable } from 'mobx';
import { Card } from '../Types';
import { game } from '.';
import PlayerCards from './PlayerCards';

class MyCards extends PlayerCards {
    cards: Array<Card> = [];

    constructor() {
        super();

        makeObservable(this, {
            cards: observable,
        });
    }
    /*
    checkMyStep(card: Card, battleFieldCards: Card[]) {
        if (game.isMyAttack) {
            return this.myAttack(card, battleFieldCards);
        }

        return this.myDefense(card, game.attackCard);
    }

    myAttack(card: Card, battleFieldCards: Card[]) {
        if (!battleFieldCards.length || battleFieldCards.some((c) => c.points === card.points)) {
            game.setAttackCard(card);
            this.reduceCard(card.id);
            return card;
        }
        alert('Такой карты нет на поле битвы');
    }

    myDefense(card: Card, attackCard: Card) {
        const strongerCard = card.points > attackCard.points;

        if (strongerCard) {
            this.reduceCard(card.id);
            return card;
        }

        alert('У него карта сильнее');
    }
    */
}

export default new MyCards();
