import { useState } from 'react';
import EvenPlayers from './components/EvenPlayers';
import { IndianPlayers } from './components/IndianPlayers';
import ListOfIndianPlayers from './components/ListOfIndianPlayers';
import ListOfPlayers from './components/ListofPlayers';
import OddPlayers from './components/OddPlayers';
import ScoreBelow70 from './components/ScoreBelow70';

function App() {
  const [flag, setFlag] = useState(true);

  const players = [
    { name: 'Rohit', score: 95 },
    { name: 'Virat', score: 55 },
    { name: 'Dhoni', score: 45 },
    { name: 'Surya', score: 75 },
    { name: 'Shami', score: 30 },
    { name: 'Ashwin', score: 78 },
    { name: 'Gill', score: 39 },
    { name: 'Rishabh', score: 40 },
    { name: 'Jadeja', score: 72 },
    { name: 'Bumrah', score: 33 },
    { name: 'Ishan', score: 63 },
  ];

  return (
    <div>
      <button onClick={() => setFlag(!flag)}>
        Toggle View (Current: {flag ? 'Players List' : 'Indian Team'})
      </button>

      <hr />

      {flag ? (
        <div>
          <h1>List of Players</h1>
          <ListOfPlayers players={players} />

          <hr />

          <h1>List of Players having Scores Less than 70</h1>
          <ScoreBelow70 players={players} />
        </div>
      ) : (
        <div>
          <h1>Indian Team</h1>

          <h2>Odd Players</h2>
          <OddPlayers players={IndianPlayers} />

          <h2>Even Players</h2>
          <EvenPlayers players={IndianPlayers} />

          <h2>List of Indian Players Merged:</h2>
          <ListOfIndianPlayers players={IndianPlayers} />
        </div>
      )}
    </div>
  );
}

export default App;
