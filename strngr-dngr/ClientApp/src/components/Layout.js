import { Container } from 'reactstrap';
import React from 'react';

export default props => (
  <div className="window">
    <Container>
      {props.children}
    </Container>
  </div>
);
