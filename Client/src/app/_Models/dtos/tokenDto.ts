export class tokenDto {
    constructor(
public acess_token: string,
    public token_type: string,
    public refresh_token: string,
    public expires_in: number,
    public scope: string,
    ){}

}

