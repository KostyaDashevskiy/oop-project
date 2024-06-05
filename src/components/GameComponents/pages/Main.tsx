import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';

import '../Table.css';

import BattleFieldComponent from '../gcomponents/BattleFieldComponent';
import HisCardsComponents from '../gcomponents/HisCardsComponent';
import MyCardsComponents from '../gcomponents/MyCardsComponent';
import { battleField, hisCards, myCards, game } from '../store/index';

//import DeckComponent from '../gcomponents/DeckComponent';
//import GameOver from '../gcomponents/GameOver';
//import MyActions from '../gcomponents/MyActions';

const Main: React.FC = observer(() => {
    const startGame = () => {
        const { firstHisCards, firstMyCards } = game.startGame();
        hisCards.addCards(firstHisCards);
        myCards.addCards(firstMyCards);
    };

    useEffect(startGame, []);
    /*
    const hisAction = () => {
        if (!game.isMyStep) {
            const battleFieldCards = [...battleField.cards.his, ...battleField.cards.my];

            const hisJuniorCard = hisCards.defineCardForAction(battleFieldCards);

            if (hisJuniorCard) {
                battleField.addHisCard(hisJuniorCard);
            } else {
                battleField.clearBattleField(myCards, hisCards);
            }
        }
    };

    useEffect(hisAction, [game.isMyStep]);

    const getCard = () => {
        myCards.addCards([...battleField.cards.my, ...battleField.cards.his]);
        game.toggleStep();
        game.setIsGetCard(true);
        battleField.clearBattleField(myCards, hisCards);
    };
    
    const clickMyCard = (card: Card) => {
        if (game.isMyStep) {
            const myStepCard = myCards.checkMyStep(card, [
                ...battleField.cards.my,
                ...battleField.cards.his,
            ]);
            if (myStepCard) {
                battleField.addMyCard(myStepCard);
            }
        }
    };
*/
    return (
        <>
            <HisCardsComponents cards={hisCards.cards} />
            <BattleFieldComponent cards={battleField.cards} />
            <MyCardsComponents cards={myCards.cards} onAtack={() => {}} /> {/*clickMyCard*/}
            {/*
            <DeckComponent trump={game.trumpCard} cardBalance={game.deckCards.length} />
            <MyActions
                isMyAttack={game.isMyAttack}
                onRepulsed={() => battleField.clearBattleField(myCards, hisCards)}
                onGetCard={getCard}
            />
            <GameOver
                isShow={!game.deckCards.length && (!myCards.cards.length || !hisCards.cards.length)}
                isMyWin={!myCards.cards.length}
                onRestartGame={startGame}
            />
            */}
        </>
    );
});

export default Main;
