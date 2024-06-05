import { observer } from 'mobx-react-lite';
import * as React from 'react';
import { fieldsCard } from '../Types';
import CardComponent from './CardComponent';

interface IBattleFieldComponentProps {
    cards: fieldsCard;
}

const BattleFieldComponent: React.FC<IBattleFieldComponentProps> = observer(({ cards }) => {
    return (
        <div>
            <div className='battleField'>
                {cards.hisSniper.map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='battleField'>
                {cards.hisDamage.map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='battleField'>
                {cards.hisShield.map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='battleField'>
                {cards.myShield.map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='battleField'>
                {cards.myDamage.map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
            <div className='battleField'>
                {cards.mySniper.map((card) => (
                    <CardComponent card={card} key={card.id} />
                ))}
            </div>
        </div>
    );
});

export default BattleFieldComponent;
