import { Team } from './team';
import { Player } from './player';

export class CoachDetails {
    Id: number;
    Name: string;
    PhoneNumber: string;
    Email: string;
    Team: Team;
    Players: Player[];
}
