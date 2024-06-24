export interface SkinModel {
    color: string;
    float: number;
    id: string;
    isDiscount: boolean;
    name: string;
    price: number;
    priceWithDiscount: number;
    rarity: string;
    releaseDate: string;
    type: {
        category: number;
        id: string;
        subcategory: number;
    };
  }
  